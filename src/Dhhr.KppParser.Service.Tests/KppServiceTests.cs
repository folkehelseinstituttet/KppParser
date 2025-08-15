using System;
using System.IO;
using System.Linq;
using Dhhr.KppParser.Service.Models;
using Dhhr.KppParser.Service.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace Dhhr.KppParser.Service.Tests
{
    [TestClass]
    public class KppServiceTests : TestBase
    {
        [TestMethod]
        public void KppService_ShouldSetMetadata_WhenParsingKpp()
        {
            // arrange
            var args = DefaultArgs();

            // act
            KppService.Run(args, null, null);

            // assert
            var file = XmlUtils.DeserializeFromFile<MsgHead>(args.OutputPath);
            var melding = file.Items.First().As<Document>().RefDoc.Item.As<RefDocContent>().Melding;

            melding.versjonUt.Should().Be(args.ProgramVersion);
            melding.fraDatoPeriode.Should().Be(args.FraDato);
            melding.tilDatoPeriode.Should().Be(args.TilDato);
            melding.leverandor.Should().Be(args.Leverandor);
            melding.navnEPJ.Should().Be(args.NavnEpj);
            melding.versjonEPJ.Should().Be(args.VersjonEpj);
        }

        [TestMethod]
        public void KppService_ShouldSetKppMessageContent_WhenParsingKpp()
        {
            // arrange
            var args = DefaultArgs();

            var expectedMelding = XmlUtils.DeserializeFromFile<Melding>("Resources/Expectations/TestMelding.xml");
            var expectations = expectedMelding.Institusjon;

            // act
            KppService.Run(args, null, null);

            // assert
            var file = XmlUtils.DeserializeFromFile<MsgHead>(args.OutputPath);
            var melding = file.Items.First().As<Document>().RefDoc.Item.As<RefDocContent>().Melding;

            melding.Institusjon.Should().BeEquivalentTo(expectations);
        }

        [TestMethod]
        public void KppService_ShouldSetMsgHeadContent_WhenParsingKpp()
        {
            // arrange
            var args = DefaultArgs();

            // act
            KppService.Run(args, null, null);

            // assert
            var msgHead = XmlUtils.DeserializeFromFile<MsgHead>(args.OutputPath);

            msgHead.MsgInfo.Type.Should().BeEquivalentTo(new CS { V = "NPR_KPP", DN = "KPP melding" });
            msgHead.MsgInfo.GenDate.Should().BeSameDateAs(DateTime.Today);
            msgHead.MsgInfo.Sender.Should().BeEquivalentTo(new Sender
            {
                Organisation = new Organisation
                {
                    OrganisationName = args.OrganizationName,
                    Ident = new[] { new Ident { Id = args.OrganizationHerId, TypeId = new CV { V = "HER", DN = "HER-Id", S = "9051" } } },
                    Organisation1 = new Organisation
                    {
                        OrganisationName = args.OrganizationName2,
                        Ident = new[] { new Ident { Id = args.OrganizationHerId2, TypeId = new CV { V = "HER", DN = "HER-Id", S = "9051" } } },
                    }
                }
            });
            msgHead.MsgInfo.Receiver.Should().BeEquivalentTo(new Receiver
            {
                Organisation = new Organisation
                {
                    OrganisationName = "FHI",
                    Ident = new[] { new Ident { Id = "85217", TypeId = new CV { V = "HER", DN = "HER-Id", S = "9051" } } },
                    Organisation1 = new Organisation
                    {
                        OrganisationName = "NPR",
                        Ident = new[] { new Ident { Id = args.FhiHerId, TypeId = new CV { V = "HER", DN = "HER-Id", S = "9051" } } }
                    }
                }
            });
            Guid.TryParse(msgHead.MsgInfo.MsgId, out _).Should().BeTrue();

            var refDoc = msgHead.Items.First().As<Document>().RefDoc;
            refDoc.Should().NotBeNull();
            refDoc.MsgType.Should().BeEquivalentTo(new CS { V = "XML", DN = "XML-instans" });
            refDoc.Item?.As<RefDocContent>()?.Melding.Should().NotBeNull();
        }

        [TestMethod]
        public void KppService_ShouldCreateValidXml_WhenParsingKpp()
        {
            // arrange
            var args = DefaultArgs();
            var schemas = SchemaLoader.LoadDirectory("Resources");

            // act
            KppService.Run(args, null, null);

            // assert
            Action verify = () => XmlUtils.ValidateXmlFile(args.OutputPath, schemas);
            verify.Should().NotThrow();
        }

        [DataTestMethod]
        [DataRow("episode_institusjoner.csv", null)]
        [DataRow(null, Constants.Episode.EmptyFileName)]
        [DataRow("episode_missing_header.csv", Constants.Episode.InvalidHeader)]
        [DataRow("does_not_exist.csv", Constants.Episode.DoesNotExist)]
        [DataRow("tjeneste.csv", Constants.Episode.InvalidHeader)]
        public void KppService_ShouldValidateCsvHeaders_WhenValidatingEpisodeInput(string fileName, string expectedError)
        {
            // arrange
            if (fileName != null)
            {
                fileName = TestDataPath(fileName);
            }

            var args = DefaultArgs();
            args.EpisodePath = fileName;

            // act
            var isValid = KppService.IsValid(args, out var errorMessage);

            // assert
            isValid.Should().Be(expectedError == null);
            errorMessage.Should().Be(expectedError ?? string.Empty);
        }

        [DataTestMethod]
        [DataRow("tjeneste.csv", null)]
        [DataRow(null, Constants.Tjeneste.EmptyFileName)]
        [DataRow("tjeneste_missing_header.csv", Constants.Tjeneste.InvalidHeader)]
        [DataRow("does_not_exist.csv", Constants.Tjeneste.DoesNotExist)]
        [DataRow("episode_institusjoner.csv", Constants.Tjeneste.InvalidHeader)]
        public void KppService_ShouldValidateCsvHeaders_WhenValidatingTjenesteInput(string fileName, string expectedError)
        {
            // arrange
            if (fileName != null)
            {
                fileName = TestDataPath(fileName);
            }

            var args = DefaultArgs();
            args.TjenestePath = fileName;

            // act
            var isValid = KppService.IsValid(args, out var errorMessage);

            // assert
            isValid.Should().Be(expectedError == null);
            errorMessage.Should().Be(expectedError ?? string.Empty);
        }

        [TestMethod]
        public void KppService_ShouldCreateBatchFiles_WhenBatchFileCreationIsEnabled_AndResultingKppFileExceedsSizeLimit_AndEpisodeFileContainsSingleInstitutionId()
        {
            // arrange
            var args = BatchFileArgs("episode_institusjon.csv");

            // act
            KppService.Run(args, null, null);

            // assert
            var singleFileExists = File.Exists(OutputFile());
            Assert.IsFalse(singleFileExists);

            var batchFilesExist = OutputBatchFiles().Length > 0;
            Assert.IsTrue(batchFilesExist);
        }

        [TestMethod]
        public void KppService_ShouldAbortProcess_WhenBatchFileCreationIsEnabled_AndResultingKppFileExceedsSizeLimit_AndEpisodeFileContainsMultipleInstitutionIds()
        {
            // arrange
            var args = BatchFileArgs();
            args.EpisodePath = TestDataPath("episode_institusjoner.csv");

            // act
            KppService.Run(args, null, null);

            // assert
            var singleFileExists = File.Exists(OutputFile());
            Assert.IsFalse(singleFileExists);

            var batchFilesExist = OutputBatchFiles().Length > 0;
            Assert.IsFalse(batchFilesExist);
        }

        [TestMethod]
        public void KppService_ShouldCreateSingleFile_WhenBatchFileCreationIsEnabled_AndResultingKppFileIsWithinSizeLimit()
        {
            // arrange
            var args = BatchFileArgs();
            args.BatchFiles.MaxFileSizeInBytes = 7000;

            // act
            KppService.Run(args, null, null);

            // assert
            var singleFileExists = File.Exists(OutputFile());
            Assert.IsTrue(singleFileExists);

            var batchFilesExist = OutputBatchFiles().Length > 0;
            Assert.IsFalse(batchFilesExist);
        }

        [TestMethod]
        public void KppService_ShouldCreateSingleFile_WhenBatchFileCreationIsDisabled()
        {
            // arrange
            var args = DefaultArgs();

            // act
            KppService.Run(args, null, null);

            // assert
            var singleFileExists = File.Exists(OutputFile());
            Assert.IsTrue(singleFileExists);

            var batchFilesExist = OutputBatchFiles().Length > 0;
            Assert.IsFalse(batchFilesExist);
        }

        [TestMethod]
        public void KppService_BatchFiles_ShouldAllHaveEqualLopenr()
        {
            // arrange
            var args = BatchFileArgs();

            // act
            KppService.Run(args, null, null);

            // assert
            var batchLopenr = OutputBatchFiles()
                .Select(XmlUtils.DeserializeFromFile<MsgHead>)
                .Select(msgHead => msgHead.Items.Single().As<Document>())
                .Select(doc => doc.RefDoc.Item.As<RefDocContent>())
                .Select(content => content.Melding.lopenr)
                .ToList();

            batchLopenr.Should().OnlyContain(lopenr => lopenr == batchLopenr[0]);
        }

        [TestMethod]
        public void KppService_BatchFiles_ShouldAllConformToSpecificLokalidentFormat()
        {
            // arrange
            var args = BatchFileArgs();

            // act
            KppService.Run(args, null, null);

            // assert
            var messages = OutputBatchFiles()
                .Select(XmlUtils.DeserializeFromFile<MsgHead>)
                .Select(msgHead => msgHead.Items.Single().As<Document>())
                .Select(doc => doc.RefDoc.Item.As<RefDocContent>())
                .Select(content => content.Melding);

            foreach (var message in messages)
            {
                var lokalidentParts = message.lokalident.Split('_');

                lokalidentParts[0].Should().Be(message.lopenr);
                lokalidentParts[1][0].Should().Be('(');
                lokalidentParts[2].Should().Be("Of");
                lokalidentParts[3][^1].Should().Be(')');

                var valueBeforeOf = lokalidentParts[1][1..];
                var valueAfterOf = lokalidentParts[3][..^1];

                int.TryParse(valueBeforeOf, out var batchMessageNumber).Should().BeTrue();
                int.TryParse(valueAfterOf, out var messagesInBatch).Should().BeTrue();

                batchMessageNumber.Should().BeLessThanOrEqualTo(messagesInBatch);
            }
        }

        [TestMethod]
        public void KppService_BatchFiles_ShouldContainTheSameEpisodes_AsSingleFile_WhenSameEpisodeFileIsUsedAsInput()
        {
            // arrange
            const string episodeFileName = "episode_institusjon.csv";

            var batchFileArgs = BatchFileArgs(episodeFileName);
            var singleFileArgs = DefaultArgs();

            singleFileArgs.EpisodePath = TestDataPath(episodeFileName);

            // act
            KppService.Run(batchFileArgs, null, null);
            KppService.Run(singleFileArgs, null, null);

            // assert
            var batchMessages = OutputBatchFiles()
                .Select(XmlUtils.DeserializeFromFile<MsgHead>)
                .Select(msgHead => msgHead.Items.Single().As<Document>())
                .Select(doc => doc.RefDoc.Item.As<RefDocContent>())
                .Select(content => content.Melding);

            var singleMessage = XmlUtils.DeserializeFromFile<MsgHead>(OutputFile())
                .Items.Single().As<Document>()
                .RefDoc.Item.As<RefDocContent>()
                .Melding;

            var episodesInBatchMessages = batchMessages
                .SelectMany(message => message.Institusjon.Single().Objektholder.Single().EpisodeKPP)
                .ToArray();

            var episodesInSingleMessage = singleMessage.Institusjon.Single().Objektholder.Single().EpisodeKPP;

            episodesInBatchMessages.Should().BeEquivalentTo(episodesInSingleMessage);
        }

        private Args BatchFileArgs(string episodeFileName = "episode_institusjon.csv")
        {
            var args = DefaultArgs();

            args.BatchFiles.EnableCreation = true;
            args.BatchFiles.MaxFileSizeInBytes = 3000;
            args.EpisodePath = TestDataPath(episodeFileName);

            return args;
        }
    }
}

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
    public class KppServiceTests
    {
        private string _outputPath;

        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void TestInit()
        {
            _outputPath = @"C:\temp\tests\KppService\";
            Directory.CreateDirectory(_outputPath);

            var outputFile = OutputFile();
            if (File.Exists(outputFile))
            {
                File.Delete(outputFile);
            }
        }

        [TestMethod]
        public void KppService_ShouldSetMetadata_WhenParsingKpp()
        {
            // arrange
            var args = DefaultArgs();

            // act
            KppService.Run(args, null);

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
            KppService.Run(args, null);

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
            KppService.Run(args, null);

            // assert
            var msgHead = XmlUtils.DeserializeFromFile<MsgHead>(args.OutputPath);

            msgHead.MsgInfo.Type.Should().BeEquivalentTo(new CS { V = "NPR_KPP", DN = "KPP melding" });
            msgHead.MsgInfo.GenDate.Should().BeSameDateAs(DateTime.Today);
            msgHead.MsgInfo.Sender.Should().BeEquivalentTo(new Sender
            {
                Organisation = new Organisation
                {
                    OrganisationName = args.OrganizationName,
                    Ident = new[] { new Ident { Id = args.OrganizationHerId, TypeId = new CV { V = "HER", DN = "HER-Id", S = "9051" } } }
                }
            });
            msgHead.MsgInfo.Receiver.Should().BeEquivalentTo(new Receiver
            {
                Organisation = new Organisation
                {
                    OrganisationName = "Helsedirektoratet",
                    Ident = new[] { new Ident { Id = args.HDirHerId, TypeId = new CV { V = "HER", DN = "HER-Id", S = "9051" } } }
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
            KppService.Run(args, null);

            // assert
            Action verify = () => XmlUtils.ValidateXmlFile(args.OutputPath, schemas);
            verify.Should().NotThrow();
        }

        [DataTestMethod]
        [DataRow("episode.csv", null)]
        [DataRow(null, Constants.Episode.EmptyFileName)]
        [DataRow("episode_missing_header.csv", Constants.Episode.InvalidHeader)]
        [DataRow("does_not_exist.csv", Constants.Episode.DoesNotExist)]
        [DataRow("tjeneste.csv", Constants.Episode.InvalidHeader)]
        public void KppService_ShouldValidateCsvHeaders_WhenValidatingEpisodeInput(string fileName, string expectedError)
        {
            // arrange
            if (fileName != null)
            {
                fileName = $"Resources/TestData/{fileName}";
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
        [DataRow("episode.csv", Constants.Tjeneste.InvalidHeader)]
        public void KppService_ShouldValidateCsvHeaders_WhenValidatingTjenesteInput(string fileName, string expectedError)
        {
            // arrange
            if (fileName != null)
            {
                fileName = $"Resources/TestData/{fileName}";
            }

            var args = DefaultArgs();
            args.TjenestePath = fileName;

            // act
            var isValid = KppService.IsValid(args, out var errorMessage);

            // assert
            isValid.Should().Be(expectedError == null);
            errorMessage.Should().Be(expectedError ?? string.Empty);
        }

        private Args DefaultArgs()
        {
            return new Args
            {
                EpisodePath = "Resources/TestData/episode.csv",
                TjenestePath = "Resources/TestData/tjeneste.csv",
                OutputPath = OutputFile(),
                ProgramVersion = TestContext.TestName,
                FraDato = new DateTime(2019, 1, 1),
                TilDato = new DateTime(2019, 12, 31),
                Leverandor = "ukjent leverandør",
                NavnEpj = "ukjent epj",
                VersjonEpj = "ukjent epj versjon",
                OrganizationName = "Avsender navn",
                OrganizationHerId = "54321",
                HDirHerId = "12345"
            };
        }

        private string OutputFile() => $"{_outputPath}{TestContext.TestName}.xml";
    }
}

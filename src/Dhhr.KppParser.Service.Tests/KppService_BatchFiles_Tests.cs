using System.IO;
using System.Linq;
using Dhhr.KppParser.Service.Models;
using Dhhr.KppParser.Service.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Moq;

namespace Dhhr.KppParser.Service.Tests;

[TestClass]
public class KppService_BatchFiles_Tests : TestBase
{
    [TestInitialize]
    public void TestInit()
    {
        TestInitBase();

        foreach (var batchFile in OutputBatchFiles())
        {
            File.Delete(batchFile);
        }
    }

    [TestMethod]
    public void KppService_ShouldCreateBatchFiles_WhenBatchFileCreationIsEnabled_AndResultingKppFileExceedsSizeLimit_AndEpisodeFileContainsSingleInstitutionId()
    {
        // arrange
        var args = BatchFileArgs("episode_larger_singleinstitution.csv");

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
        args.EpisodePath = TestDataPath("episode_larger_multipleinstitutions.csv");

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
        var args = BatchFileArgs(maxFileSizeInBytes: 7000);

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
        const string episodeFileName = "episode_larger_singleinstitution.csv";

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

    private Args BatchFileArgs(string episodeFileName = "episode_larger_singleinstitution.csv", long maxFileSizeInBytes = 5500)
    {
        var argsMock = new Mock<Args>();
        var args = argsMock.Object;

        SetDefaultValues(args);

        args.EpisodePath = TestDataPath(episodeFileName);

        args.BatchFiles = new BatchFileArgs { EnableCreation = true };

        argsMock.Setup(mock => mock.GetMaxFileSizeInBytes()).Returns(maxFileSizeInBytes);

        return args;
    }
}

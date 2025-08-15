using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dhhr.KppParser.Service.Tests;

[TestClass]
public class TestBase
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

        foreach (var batchFile in OutputBatchFiles())
        {
            File.Delete(batchFile);
        }
    }

    protected Args DefaultArgs()
    {
        return new Args
        {
            EpisodePath = TestDataPath("episode_institusjoner.csv"),
            TjenestePath = TestDataPath("tjeneste.csv"),
            OutputPath = OutputFile(),
            ProgramVersion = TestContext.TestName,
            FraDato = new DateTime(2019, 1, 1),
            TilDato = new DateTime(2019, 12, 31),
            Leverandor = "ukjent leverandør",
            NavnEpj = "ukjent epj",
            VersjonEpj = "ukjent epj versjon",
            OrganizationName = "Avsender navn",
            OrganizationHerId = "54321",
            OrganizationName2 = "Avsender navn nivå 2",
            OrganizationHerId2 = "543212",
            FhiHerId = "12345",
            BatchFiles = new BatchFileArgs(),
        };
    }

    protected string OutputFile() => $"{_outputPath}{TestContext.TestName}.xml";

    protected string[] OutputBatchFiles() => Directory.GetFiles(_outputPath, TestContext.TestName + "_*.xml");

    protected static string TestDataPath(string fileName) => Path.Combine("Resources/TestData", fileName);
}

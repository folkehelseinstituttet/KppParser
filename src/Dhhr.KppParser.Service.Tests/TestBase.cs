using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dhhr.KppParser.Service.Tests;

[TestClass]
public class TestBase
{
    private string _outputPath;

    public TestContext TestContext { get; set; }

    protected void TestInitBase()
    {
        _outputPath = @"C:\temp\tests\KppService\";
        Directory.CreateDirectory(_outputPath);

        var outputFile = OutputFile();
        if (File.Exists(outputFile))
        {
            File.Delete(outputFile);
        }
    }

    protected void SetDefaultValues(Args args)
    {
        args.EpisodePath = TestDataPath("episode.csv");
        args.TjenestePath = TestDataPath("tjeneste.csv");
        args.OutputPath = OutputFile();
        args.ProgramVersion = TestContext.TestName;
        args.FraDato = new DateTime(2019, 1, 1);
        args.TilDato = new DateTime(2019, 12, 31);
        args.Leverandor = "ukjent leverandør";
        args.NavnEpj = "ukjent epj";
        args.VersjonEpj = "ukjent epj versjon";
        args.OrganizationName = "Avsender navn";
        args.OrganizationHerId = "54321";
        args.OrganizationName2 = "Avsender navn nivå 2";
        args.OrganizationHerId2 = "543212";
        args.FhiHerId = "12345";
    }

    protected Args DefaultArgs()
    {
        var args = new Args();

        SetDefaultValues(args);

        return args;
    }

    protected string OutputFile() => $"{_outputPath}{TestContext.TestName}.xml";

    protected string[] OutputBatchFiles() => Directory.GetFiles(_outputPath, TestContext.TestName + "_*.xml");

    protected static string TestDataPath(string fileName) => Path.Combine("Resources/TestData", fileName);
}

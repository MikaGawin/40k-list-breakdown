using System.CommandLine;
using WarhammerStats.Core;

var rootCommand = new RootCommand("Warhammer Stats CLI");

//for testing if cli is working

var statusCommand = new Command("status", "Check if WarhammerStats CLI is working");

statusCommand.SetHandler(() =>
{
    Console.WriteLine("WarhammerStats CLI is ready.");
});

var versionCommand = new Command("version", "Show the current version of WarhammerStats");
versionCommand.SetHandler(() =>
{
    Console.WriteLine($"WarhammerStats CLI v{VersionInfo.Current}");
});

//update units command

var updateUnitsCommand = new Command("update-units", "Extract all units from munitorum field manual(pdf) and update database");
var pdfPathArgument = new Argument<string>("pdfPath");
updateUnitsCommand.Add(pdfPathArgument);

updateUnitsCommand.SetHandler((string pdfPath) =>
{
    var parser = new PdfParser();
    var units = parser.ExtractUnits(pdfPath);

    Console.WriteLine("Units found in PDF:");
    foreach(var unit in units)
    {
        Console.WriteLine($"- {unit}");
    }

}, pdfPathArgument);


rootCommand.AddCommand(statusCommand);
rootCommand.AddCommand(versionCommand);
rootCommand.Add(updateUnitsCommand);

return await rootCommand.InvokeAsync(args);


using System.CommandLine;
using WarhammerStats.Core;

var rootCommand = new RootCommand("Warhammer Stats CLI");

//for testing if cli is working

var helloCommand = new Command("hello", "Say hello");
var nameArgument = new Argument<string>("name");
helloCommand.Add(nameArgument);

helloCommand.SetHandler((string name) =>
{
    Console.WriteLine($"Hello, {name}!");
}, nameArgument);

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


rootCommand.Add(helloCommand);
rootCommand.Add(updateUnitsCommand);

return await rootCommand.InvokeAsync(args);


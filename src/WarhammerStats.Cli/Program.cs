using System.CommandLine;

var rootCommand = new RootCommand("Warhammer Stats CLI");

var helloCommand = new Command("hello", "Say hello");
var nameArgument = new Argument<string>("name");
helloCommand.Add(nameArgument);

helloCommand.SetHandler((string name) =>
{
    Console.WriteLine($"Hello, {name}!");
}, nameArgument);

rootCommand.Add(helloCommand);

return await rootCommand.InvokeAsync(args);
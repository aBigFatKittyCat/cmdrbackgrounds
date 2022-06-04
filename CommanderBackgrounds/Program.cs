// See https://aka.ms/new-console-template for more information
using CommanderBackgrounds;

var client = new ScryFallClient();

var commanders = await client.SearchCards("is:commander o:\"choose a background\" -\"faceless one\"");
var backgrounds = await client.SearchCards("t:background -\"faceless one\"");

Console.WriteLine("Commanders:");
Console.WriteLine("------------");
foreach (var card in commanders.data)
{
    Console.WriteLine($"{card.name}");
}

Console.WriteLine("Backgrounds:");
Console.WriteLine("------------");
foreach (var card in backgrounds.data)
{
    Console.WriteLine($"{card.name}");
}
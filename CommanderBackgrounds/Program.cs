// See https://aka.ms/new-console-template for more information
using CommanderBackgrounds;

var client = new ScryFallClient();

var commanders = await client.SearchCards("is%3Acommander+o%3A\"choose + a + background\"+-\"faceless + one\"");
var backgrounds = await client.SearchCards("t%3Abackground+-\"faceless + one\"");

var colors = new string[] { "B", "W", "U", "R", "G" };

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
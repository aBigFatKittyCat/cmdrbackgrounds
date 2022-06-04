// See https://aka.ms/new-console-template for more information
using CommanderBackgrounds;
using CsvHelper;
using System.Globalization;

var client = new ScryFallClient();

var commanders = await client.SearchCards("is%3Acommander+o%3A\"choose + a + background\"+-\"faceless + one\"");
var backgrounds = await client.SearchCards("t%3Abackground+-\"faceless + one\"");

var colors = new Dictionary<string, Tuple<string, string>>();
colors.Add("MONOBLACK", new("B", "B"));

List<BackgroundPair> records;

var configuration = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture);
configuration.Delimiter = "\t";

foreach (var color in colors.Keys)
{
    records = new();
    foreach (var commander in commanders.data.Where(c => c.color_identity.First() == colors[color].Item1))
    {
        foreach (var background in backgrounds.data.Where(c => c.color_identity.First() == colors[color].Item2))
        {
            records.Add(new()
            {
                CommanderName = commander.name,
                CommanderImageUri = $"=IMAGE(\"{commander.image_uris["large"]}\", 3)",
                BackgroundName = background.name,
                BackgroundImageUri = $"=IMAGE(\"{background.image_uris["large"]}\", 3)"

            });
        }

    }
    using (var writer = new StreamWriter($"C:\\Users\\Peter\\Documents\\commanderbackgrounds\\{color}.csv"))
    using (var csv = new CsvWriter(writer, configuration))
    {
        csv.WriteRecords(records);
    }
}


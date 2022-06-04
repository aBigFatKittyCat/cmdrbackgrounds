namespace CommanderBackgrounds
{
    public class Card
    {
        public Guid id { get; set; }

        public string name { get; set; }

        public string[] color_identity { get; set; }

        public Dictionary<string, Uri> image_uris { get; set; }



    }
    public class CardList
    {
        public CardList()
        {
            data = new();
        }
        public List<Card> data { get; set; }
    }
}
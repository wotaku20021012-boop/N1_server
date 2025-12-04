namespace personalbeauty.Models
{
    public class Cosmetic
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string SkinType { get; set; } = "";
        public string Problem { get; set; } = "";
        public List<string> Tags { get; set; } = new();
        public int Price { get; set; }
    }
}

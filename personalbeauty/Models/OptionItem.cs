namespace personalbeauty.Models
{
    public class OptionItem
    {
        public string Label { get; set; } = "";
        public string Value { get; set; } = "";
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Text { get; set; } = "";
    }
}

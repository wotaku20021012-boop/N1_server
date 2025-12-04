namespace personalbeauty.Models
{
    public class ChatLog
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string UserMessage { get; set; } = string.Empty;
        public List<string> Tags { get; set; } = new();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int QuestionId { get; set; }
        public int OptionId { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.Now;


    }
}

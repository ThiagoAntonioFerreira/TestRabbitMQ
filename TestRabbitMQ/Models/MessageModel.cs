namespace TestRabbitMQ.Models
{
    public class MessageModel
    {
        public int FromId { get; set; }
        public int ToId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}

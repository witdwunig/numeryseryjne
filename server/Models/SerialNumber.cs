namespace server.Models
{
    public class SerialNumber
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public string Number {get; set;}
        public DateTime CreatedAt {get; set;} = DateTime.UtcNow;
    }
}
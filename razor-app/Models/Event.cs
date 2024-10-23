namespace razor_app.Models;
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public byte[]? Picture { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
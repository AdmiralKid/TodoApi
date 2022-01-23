namespace TodoAPI.Models
{
    public class Todo
    {
        public Guid TodoId { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string Type { get; set; }
    }
}

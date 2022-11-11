namespace AdAstra.DataAccess.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Post Post { get; set; }
        public int PostId { get; set; }
    }
}

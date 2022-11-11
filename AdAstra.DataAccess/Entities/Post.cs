namespace AdAstra.DataAccess.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PhotoUrl { get; set; }
        public string Review { get; set; }
        public Trip Trip { get; set; }
        public int TripId { get; set; }
        public List<Comment> Comments{ get; set; }
    }
}

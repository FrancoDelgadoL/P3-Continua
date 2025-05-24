namespace P3_Continua.Models
{ 
    public class PostDetailsViewModel
    {
        public Post Post { get; set; } = new Post();
        public User User { get; set; } = new User();
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
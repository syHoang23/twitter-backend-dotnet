using System.ComponentModel.DataAnnotations;
namespace DotnetAPI.Models
{
    public partial class Post
    {
        public int? PostId {get; set;}
        public int? UserId {get; set;}
        [Required]
        public string? PostTitle {get; set;}
        [Required]
        public string? PostContent {get; set;}
        public DateTime PostCreated {get; set;}
        public DateTime PostUpdated {get; set;}

        public Post()
        {
            
        }
    }
}
using System.ComponentModel.DataAnnotations;
namespace DotnetAPI.Dtos
{
    public partial class PostForUpsertDto
    {
        public int PostId {get; set;}
        [Required]
        public string? PostTitle {get; set;}
        [Required]
        public string? PostContent {get; set;}

        public PostForUpsertDto()
        {
            
        }
    }
}
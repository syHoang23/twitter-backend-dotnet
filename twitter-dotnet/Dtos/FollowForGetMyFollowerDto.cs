using System.ComponentModel.DataAnnotations;
namespace DotnetAPI.Dtos
{
    public partial class FollowForGetMyFollowerDto
    {
        public int? FollowerId { get; set; }
        public string? FullName { get; set; }
        public DateTime FollowedAt { get; set; }
        public FollowForGetMyFollowerDto()
        {
            FollowerId = null;
            FullName = null;
            FollowedAt = DateTime.UtcNow;
        }
    }
}
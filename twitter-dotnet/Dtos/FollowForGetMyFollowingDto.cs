using System.ComponentModel.DataAnnotations;
namespace DotnetAPI.Dtos
{
    public partial class FollowForGetMyFollowingDto
    {
        public int? FollowingId { get; set; }
        public string? FullName { get; set; }
        public DateTime FollowedAt { get; set; }
        public FollowForGetMyFollowingDto()
        {
            FollowingId = null;
            FullName = null;
            FollowedAt = DateTime.UtcNow;
        }
    }
}
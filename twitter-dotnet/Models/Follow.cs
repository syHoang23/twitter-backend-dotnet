using System.ComponentModel.DataAnnotations;
namespace DotnetAPI.Models
{
    public partial class Follow
    {
        public int? FollowId { get; set; }
        public int? FollowerId { get; set; }
        public int? FollowingId { get; set; }
        public DateTime FollowedAt { get; set; }


        public Follow()
        {
            FollowId = null;
            FollowerId = null;
            FollowingId = null;
            FollowedAt = DateTime.UtcNow;
        }
    }
}
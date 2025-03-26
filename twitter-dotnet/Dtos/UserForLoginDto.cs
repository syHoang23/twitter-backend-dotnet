using System.ComponentModel.DataAnnotations;
namespace DotnetAPI.Dtos
{
    public partial class UserForLoginDto
    {
        
        [Required]
        [EmailAddress(ErrorMessage = "Email không hợp lệ.")]    
        public string? Email {get; set;}
        [Required]
        public string? Password {get; set;}
        public UserForLoginDto()
        {
            
        }
    }
}
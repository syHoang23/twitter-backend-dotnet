using System.ComponentModel.DataAnnotations;
namespace DotnetAPI.Dtos
{
    public partial class UserForRegistrationDto
    {
        [Required]
        [EmailAddress(ErrorMessage = "Email không hợp lệ.")]
        public string Email {get; set;}
        
        [Required]
        [MinLength(6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự.")]
        public string Password {get; set;}
        [Required]
        [Compare("Password", ErrorMessage = "Xác nhận mật khẩu không khớp.")]
        public string? PasswordConfirm {get; set;}
        [Required]
        public string? FirstName {get; set;}
        [Required]
        public string? LastName {get; set;}
        [Required]
        public string? Gender {get; set;}
        [Required]
        public string? JobTitle {get; set;}
        [Required]
        public string? Department {get; set;}
        [Range(0, double.MaxValue, ErrorMessage = "Lương phải lớn hơn 0.")]
        [Required]
        public decimal? Salary {get; set;}

        public UserForRegistrationDto()
        {
            if(string.IsNullOrEmpty(Email))
            {
                Email = string.Empty;
            }
            if(string.IsNullOrEmpty(Password))
            {
                Password = string.Empty;
            }
        }
    }
}
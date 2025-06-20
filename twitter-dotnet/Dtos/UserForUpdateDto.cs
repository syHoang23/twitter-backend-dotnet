using System.ComponentModel.DataAnnotations;
namespace DotnetAPI.Dtos
{
    public partial class UserForUpdateDto
    {
        [Required]
        public string? FirstName {get; set;}
        [Required]
        public string? LastName {get; set;}
        [Required]
        [EmailAddress(ErrorMessage = "Email không hợp lệ.")]
        public string? Email {get; set;}
        [Required]
        public string? Gender {get; set;}
        [Required]
        public bool? Active {get; set;}
        [Required]
        public string? JobTitle {get; set;}
        [Required]
        public string? Department {get; set;}
        [Required]
        public decimal? Salary {get; set;}
        [Required]
        public decimal? AvgSalary {get; set;}
    }
}
using System.ComponentModel.DataAnnotations;

namespace FinanceManagerAPI.DTO {
    
    #pragma warning disable CS8618
    public class UserAccountCreateDto {

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
    #pragma warning restore CS8618

    public class UserAccountUpdateDto {

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

    }
}

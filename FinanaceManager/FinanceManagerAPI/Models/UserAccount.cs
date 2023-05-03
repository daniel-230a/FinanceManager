using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceManagerAPI.Models {

    [Table("user_accounts")]
    public class UserAccount {
        [Key, Column("user_id")]
        public long UserID { get; set; }
        [Column("first_name"), Required]
        public string FirstName { get; set; }
        [Column("last_name"), Required]
        public string LastName { get; set; }
        [Column("email"), Required]
        public string Email { get; set; }
        [Column("password"), Required]
        public string Password { get; set; }
        [Column("date_created"), Required]
        public DateTime DateCreated { get; set; }

        public UserAccount( string firstName, string lastName, string email, string password) {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            DateCreated = DateTime.UtcNow;
        }
    }
}
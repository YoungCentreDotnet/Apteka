using LinqToDB.Mapping;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Apteka.Backend.Model
{
    public class User
    {
        [Identity]
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTimeOffset DataOfBrith { get; set; }
        [Required]
        [EmailAddress]
        public string Login { get; set; }
        [PasswordPropertyText]
        [MaxLength(18)]
        public string Password { get; set; }


    }
}

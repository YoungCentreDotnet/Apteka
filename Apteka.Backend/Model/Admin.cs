using Apteka.Backend.Model.Position;
using LinqToDB.Mapping;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Apteka.Backend.Model
{
    public class Admin
    {
        [Identity]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Role EmployeeRole { get; set; }
        [Required]
        [EmailAddress]
        public string? Login { get; set; }
        [PasswordPropertyText]
        [MaxLength(18)]
        public string? Password { get; set; }

    }
}

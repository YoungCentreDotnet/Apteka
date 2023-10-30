﻿using LinqToDB.Mapping;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Apteka.Backend.Model
{
    public class Admin
    {
        [Identity]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Login { get; set; }
        [PasswordPropertyText]
        [MaxLength(8)]
        public string Password { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models_Entity.Entry_Models;
using Models_Entity.Models_Enum;

namespace Models_Entity.Models
{
    public class User:Entity
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required Role_enum Role { get; set; }
    }
    public class UserName
    {
        [EmailAddress]
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}

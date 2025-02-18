using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Models_Entity.Entry_Models;

namespace Models_Entity.Models
{
    public class Application:Entity
    {
        public virtual required string NameApplication { get; set; }
        public virtual required string Description { get; set; }
        public virtual required DateTime date { get; set; }
        public virtual required string Type { get; set; }
        public string? PathFile { get; set; } = string.Empty;
        [NotMapped]
        public IFormFile App { get; set; }
       public List<User> User_Developer { get; set; } = new List<User>();
       public List<User> Users { get; set; } = new List<User>();


    }
}

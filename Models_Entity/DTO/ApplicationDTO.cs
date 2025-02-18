using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Models_Entity.DTO
{
    public class ApplicationDTO
    {
        public virtual required string NameApplication { get; set; }
        public virtual required string Description { get; set; }
        public virtual required DateTime date { get; set; }
        public virtual required string Type { get; set; }
        public IFormFile App { get; set; }
    }
}

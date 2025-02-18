using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Models_Entity.Entry_Models;

namespace Models_Entity.Models_Summary
{
    public class ApplicationSummary:Entity
    {
        public virtual required string NameApplication { get; set; }
        public virtual required string Description { get; set; }
        public virtual required DateTime date { get; set; }
        public virtual required string Type { get; set; }
        public IFormFile App { get; set; }
    }
}

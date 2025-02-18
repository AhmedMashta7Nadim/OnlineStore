using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Models_Entity.Models;

namespace Models_Entity.DTO
{
    public class UserApplicationDTO
    {
        public virtual required Guid UserId { get; set; }
        public virtual required Guid ApplicationId { get; set; }
    }
}

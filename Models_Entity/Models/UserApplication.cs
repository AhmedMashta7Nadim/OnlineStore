using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Models_Entity.Entry_Models;

namespace Models_Entity.Models
{
    public class UserApplication:Entity
    {
        public virtual required DateTime date { get; set; }=DateTime.UtcNow;
        public virtual required Guid UserId { get; set; }
        [JsonIgnore]
        [NotMapped]
        public User? user { get; set; }
        public virtual required Guid ApplicationId { get; set; }
        [JsonIgnore]
        [NotMapped]
        public Application? application { get; set; }
    }
}

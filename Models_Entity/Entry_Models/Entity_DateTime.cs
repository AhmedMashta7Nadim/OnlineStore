using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models_Entity.Entry_Models
{
    public class Entity_DateTime : IEntity_DateTime
    {
        public DateTime date { get; set; } = DateTime.UtcNow;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models_Entity.Entry_Models
{
    public class Entity : IEntity
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; } = true;
        public Entity()
        {
            Id= Guid.NewGuid();
        }
    }
}

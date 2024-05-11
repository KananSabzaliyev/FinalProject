using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Models
{
    public class Gear:BaseEntity
    {
        public Gear()
        {
            Cars = new HashSet<Car>();
        }
        public string Name { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}

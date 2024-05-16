using Core.Entites;

namespace Entities.Concrete.Models
{
    public class Gear:BaseEntity
    {
        public Gear()
        {
            Cars = new HashSet<Car>();
        }
        public string GearName { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}

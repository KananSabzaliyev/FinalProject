using Core.Entites;

namespace Entities.Concrete.Models
{
    public class Brand:BaseEntity
    {
        public Brand()
        {
            Cars = new HashSet<Car>();
        }
        public string Name { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}

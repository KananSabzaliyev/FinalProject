using Core.Entites;

namespace Entities.Concrete.Models
{
    public class Brand:BaseEntity
    {
        public Brand()
        {
            Cars = new HashSet<Car>();
        }
        public string BrandName { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}

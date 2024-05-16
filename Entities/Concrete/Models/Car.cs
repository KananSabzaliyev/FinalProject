using Core.Entites;

namespace Entities.Concrete.Models
{
    public class Car:BaseEntity
    {
        public string CarHp { get; set; }
        public string CarModel { get; set; }
        public string CarCondition { get; set; }
        public decimal CarPrice { get; set; }
        public string CarYear { get; set; }
        public string CarPhotoUrl { get; set; }
        public int BranId { get; set; }
        public virtual Brand Brand { get; set; }
        public int GearId { get; set; }
        public virtual Gear Gear { get; set; }
        public int CarBodyId { get; set; }
        public virtual CarBody CarBody { get; set; }
    }
}

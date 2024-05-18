namespace Entities.Concrete.Dtos.Car
{
    public class CarUpdateDto
    {
        public int CarId { get; set; }
        public string CarHp { get; set; }
        public string CarModel { get; set; }
        public string CarCondition { get; set; }
        public decimal CarPrice { get; set; }
        public string CarYear { get; set; }
        public string CarPhotoUrl { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public int CarBodyId { get; set; }
        public string CarBodyName { get; set; }
        public int GearId { get; set; }
        public string GearName { get; set; }
    }
}

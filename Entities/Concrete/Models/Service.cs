using Core.Entites;

namespace Entities.Concrete.Models
{
    public class Service:BaseEntity
    {
        public string ServiceIconName { get; set; }
        public string ServiceTitle { get; set; }
        public string ServiceDescription { get; set; }
    }
}

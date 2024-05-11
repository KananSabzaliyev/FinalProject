using Core.Entites;

namespace Entities.Concrete.Models
{
    public class Service:BaseEntity
    {
        public string IconName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}

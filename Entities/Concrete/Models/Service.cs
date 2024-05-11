using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Models
{
    public class Service:BaseEntity
    {
        public string IconName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}

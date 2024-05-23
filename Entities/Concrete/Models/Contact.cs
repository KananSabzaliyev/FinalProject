using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Models
{
    public class Contact:BaseEntity
    {
        public string ContactName{ get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string ContactMessage { get; set; }
        public string IconUrl { get; set; }
    }
}

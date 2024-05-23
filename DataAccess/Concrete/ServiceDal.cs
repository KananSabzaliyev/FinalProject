using Core.DatatAccess.Concrete;
using DataAccess.Abstarct;
using DataAccess.SqlDbContext;
using Entities.Concrete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class ServiceDal:BaseRepository<Service,ApplicationDbContext>,IServiceDal
    {
    }
}

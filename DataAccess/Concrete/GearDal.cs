using Core.DatatAccess.Concrete;
using DataAccess.Abstarct;
using DataAccess.SqlDbContext;
using Entities.Concrete.Models;

namespace DataAccess.Concrete
{
    public class GearDal : BaseRepository<Gear, ApplicationDbContext>,IGearDal
    {

    }
}

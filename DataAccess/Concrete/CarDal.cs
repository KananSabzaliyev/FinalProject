using Core.DatatAccess.Concrete;
using DataAccess.Abstarct;
using DataAccess.SqlDbContext;
using Entities.Concrete.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class CarDal : BaseRepository<Car, ApplicationDbContext>, ICarDal
    {
        ApplicationDbContext context = new();
        public List<Car> GetCarWithDetails()
        {
            var data = context.Cars
                                .Where(x => x.Deleted == 0)
                                .Include(x => x.Brand)
                                .Include(x=>x.CarBody)
                                .Include(x=>x.Gear)
                                .ToList();
            return data;
        }
    }
}

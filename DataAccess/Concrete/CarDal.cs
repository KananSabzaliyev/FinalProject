using Core.DatatAccess.Concrete;
using DataAccess.Abstarct;
using DataAccess.SqlDbContext;
using Entities.Concrete.Dtos;
using Entities.Concrete.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class CarDal : BaseRepository<Car, ApplicationDbContext>, ICarDal
    {
        ApplicationDbContext _context = new();
        public List<CarDto> GetCarWithDetails()
        {
            //var data = _context.Cars
            //                    .Where(x => x.Deleted == 0)
            //                    .Include(x => x.Brand)
            //                    .Include(x=>x.CarBody)
            //                    .Include(x=>x.Gear)
            //                    .ToList();
            //return data;

            var result = from car in _context.Cars
                         where car.Deleted == 0
                         join brand in _context.Brands
                         on car.BranId equals brand.Id
                         where brand.Deleted == 0

                         join carbody in _context.CarBodies
                         on car.CarBodyId equals carbody.Id
                         where carbody.Deleted == 0

                         join gear in _context.Gears
                         on car.GearId equals gear.Id
                         where gear.Deleted == 0

                         select new CarDto
                         {
                             CarId = car.Id,
                             CarHp = car.CarHp,
                             CarModel = car.CarModel,
                             CarCondition = car.CarCondition,
                             CarPrice = car.CarPrice,
                             CarYear = car.CarYear,
                             CarPhotoUrl = car.CarPhotoUrl,
                             BrandId = brand.Id,
                             BrandName = brand.BrandName,
                             CarBodyId = carbody.Id,
                             CarBodyName = carbody.CarBodyName,
                             GearId = gear.Id,
                             GearName = gear.GearName,
                         };
            return result.ToList();

        }
    }
}

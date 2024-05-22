using Core.DatatAccess.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.Models;

namespace DataAccess.Abstarct
{
    public interface ICarDal:IBaseRepository<Car>
    {
        List<CarDto> GetCarWithDetails();
    }
}

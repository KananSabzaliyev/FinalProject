using Core.DatatAccess.Abstract;
using Entities.Concrete.Models;

namespace DataAccess.Abstarct
{
    public interface ICarDal:IBaseRepository<Car>
    {
        List<Car> GetCarWithDetails();
    }
}

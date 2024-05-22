using Core.Results.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.Models;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car entity);
        IResult Update(Car entity);
        IResult Delete(int id);
        IDataResult<List<Car>> GetAll();
        IDataResult<List<CarDto>> GetAllWithDetails();
        IDataResult<Car> GetById(int id);
    }
}

using Core.Results.Abstract;
using Entities.Concrete.Models;

namespace Business.Abstract
{
    public interface IBrandservice
    {
        IResult Add(Brand entity);
        IResult Update(Brand entity);
        IResult Delete(int id);
        IDataResult<List<Brand>> GetAll();
        IDataResult<Brand> GetById(int id);
    }
}

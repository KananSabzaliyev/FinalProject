using Core.Results.Abstract;
using Entities.Concrete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarbodyService
    {
        IResult Add(CarBody entity);
        IResult Update(CarBody entity);
        IResult Delete(int id);
        IDataResult<List<CarBody>> GetAll();
        IDataResult<CarBody> GetById(int id);
    }
}

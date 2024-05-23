using Core.Results.Abstract;
using Entities.Concrete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IServiceservice
    {
        IResult Add(Service entity);
        IResult Update(Service entity);
        IResult Delete(int id);
        IDataResult<List<Service>> GetAll();
        IDataResult<Service> GetById(int id);
    }
}

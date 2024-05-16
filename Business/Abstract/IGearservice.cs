using Core.Results.Abstract;
using Entities.Concrete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGearservice
    {
        IResult Add(Gear entity);
        IResult Update(Gear entity);
        IResult Delete(int id);
        IDataResult<List<Gear>> GetAll();
        IDataResult<Gear> GetById(int id);
    }
}

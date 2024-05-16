using Business.Abstract;
using Business.BaseMessage;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Concrete;
using Entities.Concrete.Models;

namespace Business.Concrete
{
    public class BrandManager : IBrandservice
    {
        BrandDal brandDal = new();
        public IResult Add(Brand entity)
        {
            brandDal.Add(entity);
            return new SuccessResult(UIMessage.ADDED_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;
            brandDal.Update(data);
            return new SuccessResult(UIMessage.DELETE_MESSAGE);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(brandDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(brandDal.GetById(id));
        }

        public IResult Update(Brand entity)
        {
            entity.LastUpdateDate = DateTime.Now;
            brandDal.Update(entity);
            return new SuccessResult(UIMessage.UPDATE_MESSAGE);
        }
    }
}

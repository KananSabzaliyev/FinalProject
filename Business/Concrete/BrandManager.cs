using Business.Abstract;
using Business.BaseMessage;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstarct;
using DataAccess.Concrete;
using Entities.Concrete.Models;

namespace Business.Concrete
{
    public class BrandManager : IBrandservice
    {
        private readonly IBrandDal _branDal;
        public BrandManager(IBrandDal brandDal)
        {
            _branDal = brandDal;
        }
        public IResult Add(Brand entity)
        {
            _branDal.Add(entity);
            return new SuccessResult(UIMessage.ADDED_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;
            _branDal.Update(data);
            return new SuccessResult(UIMessage.DELETE_MESSAGE);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_branDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_branDal.GetById(id));
        }

        public IResult Update(Brand entity)
        {
            entity.LastUpdateDate = DateTime.Now;
            _branDal.Update(entity);
            return new SuccessResult(UIMessage.UPDATE_MESSAGE);
        }
    }
}

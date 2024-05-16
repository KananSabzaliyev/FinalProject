using Business.Abstract;
using Business.BaseMessage;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Concrete;
using Entities.Concrete.Models;

namespace Business.Concrete
{
    public class CarBodyManager : ICarbodyService
    {
        CarBodyDal _carBodyDal = new();
        public IResult Add(CarBody entity)
        {
            _carBodyDal.Add(entity);
            return new SuccessResult(UIMessage.ADDED_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;
            _carBodyDal.Update(data);
            return new SuccessResult(UIMessage.DELETE_MESSAGE);
        }

        public IDataResult<List<CarBody>> GetAll()
        {
            return new SuccessDataResult<List<CarBody>>(_carBodyDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<CarBody> GetById(int id)
        {
            return new SuccessDataResult<CarBody>(_carBodyDal.GetById(id));
        }

        public IResult Update(CarBody entity)
        {
            entity.LastUpdateDate = DateTime.Now;
            _carBodyDal.Update(entity);
            return new SuccessResult(UIMessage.UPDATE_MESSAGE);
        }
    }
}

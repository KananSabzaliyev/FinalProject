using Business.Abstract;
using Business.BaseMessage;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstarct;
using DataAccess.Concrete;
using Entities.Concrete.Models;

namespace Business.Concrete
{
    public class CarBodyManager : ICarbodyService
    {
        private readonly ICarBodyDal _carbodyDal;
        public CarBodyManager(ICarBodyDal carbodyDal)
        {
            _carbodyDal = carbodyDal;
        }
        public IResult Add(CarBody entity)
        {
            _carbodyDal.Add(entity);
            return new SuccessResult(UIMessage.ADDED_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;
            _carbodyDal.Update(data);
            return new SuccessResult(UIMessage.DELETE_MESSAGE);
        }

        public IDataResult<List<CarBody>> GetAll()
        {
            return new SuccessDataResult<List<CarBody>>(_carbodyDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<CarBody> GetById(int id)
        {
            return new SuccessDataResult<CarBody>(_carbodyDal.GetById(id));
        }

        public IResult Update(CarBody entity)
        {
            entity.LastUpdateDate = DateTime.Now;
            _carbodyDal.Update(entity);
            return new SuccessResult(UIMessage.UPDATE_MESSAGE);
        }
    }
}

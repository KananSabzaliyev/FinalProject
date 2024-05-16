using Business.Abstract;
using Business.BaseMessage;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Concrete;
using Entities.Concrete.Models;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        CarDal carDal = new CarDal();
        public IResult Add(Car entity)
        {
            carDal.Add(entity);
            return new SuccessResult(UIMessage.ADDED_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;
            carDal.Update(data);
            return new SuccessResult(UIMessage.DELETE_MESSAGE);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(carDal.GetAll(x=>x.Deleted==0));
        }

        public IDataResult<List<Car>> GetAllWithDetails()
        {
            return new SuccessDataResult<List<Car>>(carDal.GetCarWithDetails());
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(carDal.GetById(id));
        }

        public IResult Update(Car entity)
        {
            entity.LastUpdateDate = DateTime.Now;
            carDal.Update(entity);
            return new SuccessResult(UIMessage.UPDATE_MESSAGE);
        }
    }
}

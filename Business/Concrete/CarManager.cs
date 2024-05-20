using Business.Abstract;
using Business.BaseMessage;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstarct;
using DataAccess.Concrete;
using Entities.Concrete.Models;
using FluentValidation;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;
       // private readonly IValidator<Car> _validator;
        public CarManager(ICarDal carDal)// IValidator<Car> validator)
        {
            _carDal = carDal;
            //_validator = validator;
        }
        public IResult Add(Car entity)
        {
            _carDal.Add(entity);
            return new SuccessResult(UIMessage.ADDED_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;
            _carDal.Update(data);
            return new SuccessResult(UIMessage.DELETE_MESSAGE);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(x=>x.Deleted==0));
        }

        public IDataResult<List<Car>> GetAllWithDetails()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetCarWithDetails());
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.GetById(id));
        }

        public IResult Update(Car entity)
        {
            entity.LastUpdateDate = DateTime.Now;
            _carDal.Update(entity);
            return new SuccessResult(UIMessage.UPDATE_MESSAGE);
        }
    }
}

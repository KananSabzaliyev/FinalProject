using Business.Abstract;
using Business.BaseMessage;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstarct;
using Entities.Concrete.Models;

namespace Business.Concrete
{
    public class GearManager : IGearservice
    {
        private readonly IGearDal _gearDal;
        public GearManager(IGearDal gearDal)
        {
            _gearDal = gearDal;
        }
        public IResult Add(Gear entity)
        {
            _gearDal.Add(entity);
            return new SuccessResult(UIMessage.ADDED_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;
            _gearDal.Update(data);
            return new SuccessResult(UIMessage.DELETE_MESSAGE);
        }

        public IDataResult<List<Gear>> GetAll()
        {
            return new SuccessDataResult<List<Gear>>(_gearDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<Gear> GetById(int id)
        {
            return new SuccessDataResult<Gear>(_gearDal.GetById(id));
        }

        public IResult Update(Gear entity)
        {
            entity.LastUpdateDate = DateTime.Now;
            _gearDal.Update(entity);
            return new SuccessResult(UIMessage.UPDATE_MESSAGE);
        }
    }
}

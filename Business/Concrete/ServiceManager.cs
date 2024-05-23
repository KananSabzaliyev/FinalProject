using Business.Abstract;
using Business.BaseMessage;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstarct;
using DataAccess.Concrete;
using Entities.Concrete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ServiceManager : IServiceservice
    {
        private readonly IServiceDal _serviceDal;
        public ServiceManager(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }
        public IResult Add(Service entity)
        {
            _serviceDal.Add(entity);
            return new SuccessResult(UIMessage.ADDED_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;
            _serviceDal.Update(data);
            return new SuccessResult(UIMessage.DELETE_MESSAGE);
        }

        public IDataResult<List<Service>> GetAll()
        {
            return new SuccessDataResult<List<Service>>(_serviceDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<Service> GetById(int id)
        {
            return new SuccessDataResult<Service>(_serviceDal.GetById(id));
        }

        public IResult Update(Service entity)
        {
            entity.LastUpdateDate = DateTime.Now;
            _serviceDal.Update(entity);
            return new SuccessResult(UIMessage.UPDATE_MESSAGE);
        }
    }
}

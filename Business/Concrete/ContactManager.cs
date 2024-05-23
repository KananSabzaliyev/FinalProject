using Business.Abstract;
using Business.BaseMessage;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstarct;
using DataAccess.Concrete;
using Entities.Concrete.Models;

namespace Business.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;
        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;   
        }
        public IResult Add(Contact entity)
        {
            _contactDal.Add(entity);
            return new SuccessResult(UIMessage.ADDED_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;
            _contactDal.Update(data);
            return new SuccessResult(UIMessage.DELETE_MESSAGE);
        }

        public IDataResult<List<Contact>> GetAll()
        {
            return new SuccessDataResult<List<Contact>>(_contactDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<Contact> GetById(int id)
        {
            return new SuccessDataResult<Contact>(_contactDal.GetById(id));
        }

        public IResult Update(Contact entity)
        {
            entity.LastUpdateDate = DateTime.Now;
            _contactDal.Update(entity);
            return new SuccessResult(UIMessage.UPDATE_MESSAGE);
        }
    }
}

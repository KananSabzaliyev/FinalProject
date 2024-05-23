using Core.DatatAccess.Concrete;
using DataAccess.Abstarct;
using DataAccess.SqlDbContext;
using Entities.Concrete.Models;

namespace DataAccess.Concrete
{
    public class ContactDal: BaseRepository<Contact, ApplicationDbContext>, IContactDal
    {
    }
}

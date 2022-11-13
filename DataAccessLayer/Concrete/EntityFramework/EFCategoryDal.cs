using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLayer.Concrete
{
    public class EFCategoryDal:GenericRepository<Category>,ICategoryDal
    {

    }
}

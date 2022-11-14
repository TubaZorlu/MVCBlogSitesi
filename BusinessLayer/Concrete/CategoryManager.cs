using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete; 
using System.Collections.Generic; 

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void TDelete(Category t)
        {
            _categoryDal.Delete(t);
        }

        public Category TGetByID(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Category> TGetList()
        {
            return _categoryDal.List();
        }

        public void TInsert(Category t)
        {
            _categoryDal.Insert(t);
        }

        public void TUpdate(Category t)
        {
            throw new System.NotImplementedException();
        }
    }
}

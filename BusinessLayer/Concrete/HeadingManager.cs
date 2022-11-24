using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class HeadingManager : IHeadingService
    {
        private readonly IHeadingDal _headingDal;
       

        public HeadingManager(IHeadingDal headingDal, Context context)
        {
            _headingDal = headingDal;
           
        }

        public Heading GetId(int id)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Heading t)
        {
            _headingDal.Delete(t);
        }

        public Heading TGetByID(int id)
        {
            return _headingDal.GetById(id);
        }

        public List<Heading> TGetList()
        {
            return _headingDal.List();
        }

        public List<Heading> TGetListByWriter(int id)
        {
            return _headingDal.GetListByWriter(id);

        }

        public void TInsert(Heading t)
        {
            _headingDal.Insert(t);
        }

        public void TUpdate(Heading t)
        {
            _headingDal.Update(t);
        }
    }
}

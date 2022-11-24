using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public Writer GetId(int id)
        {

            return _writerDal.Get(x => x.WriterID == id);
        }

        public void TDelete(Writer t)
        {
            _writerDal.Delete(t);
        }

        public Writer TGetByID(int id)
        {
            return _writerDal.GetById(id);
        }

        public List<Writer> TGetList()
        {
            return _writerDal.List();
        }

        public void TInsert(Writer t)
        {
            _writerDal.Insert(t);
        }

        public void TUpdate(Writer t)
        {
            _writerDal.Update(t);
        }

        
    }
}

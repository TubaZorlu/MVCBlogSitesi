using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
 

        private readonly IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public Meassage GetId(int id)
        {
            return _messageDal.GetById(id);
        }

        public void TDelete(Meassage t)
        {
            _messageDal.Delete(t);
        }

        public Meassage TGetByID(int id)
        {
            return _messageDal.GetById(id);
        }

        public List<Meassage> TGetList()
        {
            return _messageDal.List();
        }

        public List<Meassage> TGetlistInbox()
        {
            return _messageDal.GetlistInbox();
        }

        public List<Meassage> TGetlistSendbox()
        {
           
            return _messageDal.GetlistSendbox();
        }

        public void TInsert(Meassage t)
        {
            _messageDal.Insert(t);
        }

        public void TUpdate(Meassage t)
        {
            _messageDal.Update(t);
        }
    }
}

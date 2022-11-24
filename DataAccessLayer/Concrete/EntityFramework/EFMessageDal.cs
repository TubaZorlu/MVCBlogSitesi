using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EFMessageDal : GenericRepository<Meassage>, IMessageDal
    {
        public List<Meassage> GetlistInbox()
        {
            using (var context = new Context())
            {
                return context.Meassages.Where(x => x.ReceiverMail == "admin@gmail.com").ToList();
            }
        }

        public List<Meassage> GetlistSendbox()
        {
            using (var context = new Context())
            {
                return context.Meassages.Where(x => x.SenderMail == "admin@gmail.com").ToList();
            }
        }
    }
}

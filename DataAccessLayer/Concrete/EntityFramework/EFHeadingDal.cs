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
    public class EFHeadingDal : GenericRepository<Heading>, IHeadingDal
    {
   
        public List<Heading> GetListByWriter(int id)
        {

            using (var context = new Context())
            {
                return context.Headings.Where(x => x.Writer.WriterID == id).ToList();
              
            }
        }
    }
}

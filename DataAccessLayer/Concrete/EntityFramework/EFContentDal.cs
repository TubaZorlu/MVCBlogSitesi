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
    public class EFContentDal : GenericRepository<Content>, IContentDal
    {
        public List<Content> GetListAll(string p)
        {
            using (var context = new Context())
            {
                var values = context.Contents.Where(x => x.ContentValue.Contains(p)).ToList();

                return values;
            }
        }

        public List<Content> GetListByHeadingId(int id)
        {
    
            using (var context = new Context()) 
            {
                var values = context.Contents.Where(x => x.HeadingID == id).ToList();
             
                return values;
                 
            }
        }
    }
}

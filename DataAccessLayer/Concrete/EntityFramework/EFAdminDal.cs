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
    public class EFAdminDal : GenericRepository<Admin>, IAdminDal
    {
        public Admin GirisYap(Admin admin)
        {
            using (var context = new Context()) 
            {
                var giris = context.Admins.Where(x => x.AdminUserName == admin.AdminUserName && x.AdminPassword == admin.AdminPassword).FirstOrDefault();

                return giris;


            }
        }
    }
}

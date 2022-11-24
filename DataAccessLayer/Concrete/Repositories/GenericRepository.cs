using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
       private readonly Context c = new Context();
       private readonly DbSet<T> entity;

        public GenericRepository()
        {
            entity = c.Set<T>();
        }

        public void Delete(T p)
        {
            var deletedEntity = c.Entry(p);
            deletedEntity.State = EntityState.Deleted;
            //entity.Remove(p);
            c.SaveChanges();
        }

        // getbyid için farklı bir yöntem
        public T Get(Expression<Func<T, bool>> filter)
        {
            return entity.SingleOrDefault(filter);
        }

        public T GetById(int id)
        {
            return entity.Find(id);
        }

        public void Insert(T p)
        {
            var addEntity = c.Entry(p);
            addEntity.State = EntityState.Added;
            //entity.Add(p);
            c.SaveChanges();

        }

        public List<T> List()
        {
            return entity.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return entity.Where(filter).ToList();
        }

        public void Update(T p)
        {
            // bu kod çalışmadı
           
            //var updatedentiy = c.Entry(p);
            //updatedentiy.State = EntityState.Modified;
            c.SaveChanges();
        }
    }
}

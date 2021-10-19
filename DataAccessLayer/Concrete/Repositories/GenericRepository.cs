using DataAccessLayer.Abstractt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        Context c = new Context();

        public void Delete(T p)
        {
            c.Remove(p);
            c.SaveChanges();
        }

        public T GetById(int id)
        {
            return c.Set<T>().Find(id);
        }

        public void Insert(T p)
        {
            c.Add(p);
            c.SaveChanges();
        }

        public List<T> List()
        {
            return c.Set<T>().ToList();
        }
        public void Update(T p)
        {
            c.Update(p);
            c.SaveChanges();
        }
    }
}

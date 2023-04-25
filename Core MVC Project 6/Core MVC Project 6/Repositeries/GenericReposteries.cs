using Core_MVC_Project_6.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace Core_MVC_Project_6.Repositeries
{
	public class GenericReposteries<T> where T : class, new()
	{
		Context c = new Context();
		public List<T> TList()
		{
			return c.Set<T>().ToList();
		}
        public List<T> TList(string p)
        {
            return c.Set<T>().Include(p).ToList();
        }

        public void AddT(T parameter)
		{
			c.Set<T>().Add(parameter);
			c.SaveChanges();
		}

		public void DeleteT(T parameter)
		{
			c.Set<T>().Remove(parameter);
			c.SaveChanges();
		}

		public void UpdateT(T parameter)
		{
			c.Set<T>().Update(parameter);
			c.SaveChanges();
		}

		public T GetT(int id)
		{
			return c.Set<T>().Find(id);
		}

		public List<T> T2List(Expression<Func<T,bool>> filter) 
		{
			return c.Set<T>().Where(filter).ToList();
		}
	}
}

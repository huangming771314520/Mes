using Hbms.Mes.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hbms.Mes.DAL
{
    public class BaseDal<T> where T : class, new()
    {
        public DbContext db
        {
            get
            {
                return DbContextFactory.CreateDbContext();
            }
        }
        public bool Delete(T Model)
        {
            db.Entry<T>(Model).State = EntityState.Deleted;
            return true;
        }

        public T GetModel(Expression<Func<T, bool>> Where)
        {
            return db.Set<T>().Where(Where).FirstOrDefault();
        }

        public IQueryable<T> GetModelList(Expression<Func<T, bool>> Where)
        {
            return db.Set<T>().Where(Where);
        }

        public IQueryable<T> GetModelListWithPaging<S>(out int TotalPage, int PageIndex, int PageSize, Expression<Func<T, bool>> Where, Expression<Func<T, S>> OrderBy, bool IsAsc)
        {
            var list = db.Set<T>().Where(Where);
            TotalPage = list.Count();
            if (IsAsc)
            {
                list = list.OrderBy(OrderBy);
            }
            else
            {
                list = list.OrderByDescending(OrderBy);
            }
            return list.Skip(PageIndex - 1).Take(PageSize);
        }

        public bool Insert(T Model)
        {
            db.Set<T>().Add(Model);
            return true;
        }

        public bool Update(T Model)
        {
            db.Entry<T>(Model).State = EntityState.Modified;
            return true;
        }
    }
}

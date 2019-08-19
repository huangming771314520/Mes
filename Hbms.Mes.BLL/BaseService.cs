using Hbms.Mes.DalFactory;
using Hbms.Mes.IDAL;
using Hbms.Mes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hbms.Mes.BLL
{
    public abstract class BaseService<T> where T : class, new()
    {
        public IDbSession CurrentDbSession
        {
            get
            {
                return DbSessionFactory.CreateDbSession();
            }
        }

        public IBaseDal<T> CurrentDal { get; set; }
        public BaseService()
        {
            SetCurrentDal();
        }
        public abstract void SetCurrentDal();

        public T GetModel(Expression<Func<T, bool>> Where)
        {
            return CurrentDal.GetModel(Where);
        }
        public IQueryable<T> GetModelList(Expression<Func<T, bool>> Where)
        {
            return CurrentDal.GetModelList(Where);
        }
        public IQueryable<T> GetModelListWithPaging<S>(out int TotalPage, int PageIndex, int PageSize, Expression<Func<T, bool>> Where, Expression<Func<T, S>> OrderBy, bool IsAsc)
        {
            return CurrentDal.GetModelListWithPaging<S>(out TotalPage, PageIndex, PageSize, Where, OrderBy, IsAsc);
        }
        public bool Insert(T Model)
        {
            CurrentDal.Insert(Model);
            return CurrentDbSession.SaveChange();
        }
        public bool Update(T Model)
        {
            CurrentDal.Update(Model);
            return CurrentDbSession.SaveChange();
        }
        public bool Delete(T Model)
        {
            CurrentDal.Delete(Model);
            return CurrentDbSession.SaveChange();
        }
    }
}

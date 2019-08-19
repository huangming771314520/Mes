using Hbms.Mes.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hbms.Mes.IBLL
{
    public interface IBaseService<T>
    {
        IDbSession CurrentDbSession { get; }
        IBaseDal<T> CurrentDal { get; set; }
        T GetModel(Expression<Func<T, bool>> Where);
        IQueryable<T> GetModelList(Expression<Func<T, bool>> Where);
        IQueryable<T> GetModelListWithPaging<S>(out int TotalPage, int PageIndex, int PageSize, Expression<Func<T, bool>> Where, Expression<Func<T, S>> OrderBy, bool IsAsc);
        bool Insert(T Model);
        bool Update(T Model);
        bool Delete(T Model);
    }
}

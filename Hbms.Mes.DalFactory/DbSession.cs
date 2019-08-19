using Hbms.Mes.DAL;
using Hbms.Mes.IDAL;
using Hbms.Mes.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hbms.Mes.DalFactory
{
    public partial class DbSession : IDbSession
    {
        public DbContext db
        {
            get
            {
                return DbContextFactory.CreateDbContext();
            }
        }
        public bool SaveChange()
        {
            return db.SaveChanges() > 0;
        }
        public int ExecuteSql(string sql, params SqlParameter[] pars)
        {
            return db.Database.ExecuteSqlCommand(sql, pars);
        }
        public List<T> ExecuteQuery<T>(string sql, params SqlParameter[] pars)
        {
            return db.Database.SqlQuery<T>(sql, pars).ToList();
        }
    }
}

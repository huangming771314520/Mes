using Hbms.Mes.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Hbms.Mes.DAL
{
    public class DbContextFactory
    {
        public static DbContext CreateDbContext()
        {
            var DbContext = CallContext.GetData("DbContext") as DbContext;
            if (DbContext == null)
            {
                DbContext = new MesContainer();
                CallContext.SetData("DbContext", DbContext);
            }
            return DbContext;
        }
    }
}

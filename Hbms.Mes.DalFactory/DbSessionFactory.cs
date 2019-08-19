using Hbms.Mes.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Hbms.Mes.DalFactory
{
    public class DbSessionFactory
    {
        public static IDbSession CreateDbSession()
        {
            var DbSession = CallContext.GetData("DbSession") as IDbSession;
            if (DbSession == null)
            {
                DbSession = new DbSession();
                CallContext.SetData("DbSession", DbSession);
            }
            return DbSession;
        }
    }
}

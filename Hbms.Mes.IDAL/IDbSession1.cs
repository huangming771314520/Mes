 

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hbms.Mes.IDAL
{
	public partial interface IDbSession
    {
	
		IJQueryGanttDal JQueryGanttDal{get;}
	
		IMK_App_DTImgDal MK_App_DTImgDal{get;}
	}	
}
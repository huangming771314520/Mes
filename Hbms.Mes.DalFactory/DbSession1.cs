 
using Hbms.Mes.DAL;
using Hbms.Mes.IDAL;
using Hbms.Mes.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hbms.Mes.DalFactory
{
	public partial class DbSession : IDbSession
    {
	
		private IJQueryGanttDal _JQueryGanttDal;
        public IJQueryGanttDal JQueryGanttDal
        {
            get
            {
                if(_JQueryGanttDal == null)
                {
                    _JQueryGanttDal = AbstractFactory.CreateModelDal("JQueryGanttDal") as IJQueryGanttDal;
                }
                return _JQueryGanttDal;
            }
        }
	
		private IMK_App_DTImgDal _MK_App_DTImgDal;
        public IMK_App_DTImgDal MK_App_DTImgDal
        {
            get
            {
                if(_MK_App_DTImgDal == null)
                {
                    _MK_App_DTImgDal = AbstractFactory.CreateModelDal("MK_App_DTImgDal") as IMK_App_DTImgDal;
                }
                return _MK_App_DTImgDal;
            }
        }
	}	
}
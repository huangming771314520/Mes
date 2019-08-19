 
using Hbms.Mes.IBLL;
using Hbms.Mes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hbms.Mes.BLL
{
	
	public partial class JQueryGanttService :BaseService<JQueryGantt>,IJQueryGanttService
    {
		public override void SetCurrentDal()
        {
            CurrentDal = this.CurrentDbSession.JQueryGanttDal;
        }

        public void jq()
        {
            //this.CurrentDbSession.ExecuteSql
        }
    }   
	
	public partial class MK_App_DTImgService :BaseService<MK_App_DTImg>,IMK_App_DTImgService
    {
		public override void SetCurrentDal()
        {
            CurrentDal = this.CurrentDbSession.MK_App_DTImgDal;
        }
    }   
}
using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using M12MiniMes.Entity;
using M12MiniMes.IDAL;
using WHC.Pager.Entity;
using WHC.Framework.ControlUtil;

namespace M12MiniMes.BLL
{
    /// <summary>
    /// Ng记录表
    /// </summary>
	public class Ng记录表 : BaseBLL<Ng记录表Info>
    {
        public Ng记录表() : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }
    }
}

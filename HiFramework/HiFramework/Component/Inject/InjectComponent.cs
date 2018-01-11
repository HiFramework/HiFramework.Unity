//****************************************************************************
// Description:
// Author: hiramtan@qq.com
//****************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HiFramework
{
    class InjectComponent:Component
    {
        public InjectComponent(IContainer iContainer) : base(iContainer)
        {
        }

        public override void UnRegistComponent()
        {
            throw new NotImplementedException();
        }
    }
}

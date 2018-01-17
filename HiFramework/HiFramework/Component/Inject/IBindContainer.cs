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
    interface IBindContainer
    {
        void AddBinding(IBinding iBinding);
        void GenerateBindInfo();
        void Inject(object obj);
    }
}

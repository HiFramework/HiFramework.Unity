//****************************************************************************
// Description:
// Author: hiramtan@qq.com
//****************************************************************************
using System;

namespace HiFramework
{
    public interface IController
    {
        void Dispatch(Message param);
    }
}
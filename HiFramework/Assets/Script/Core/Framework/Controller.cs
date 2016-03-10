//****************************************************************************
// Description:控制逻辑
// Author: hiramtan@qq.com
//****************************************************************************
using System;
namespace HiFramework
{
    public abstract class Controller : Logic, IController
    {
        private View view;
        public Controller(View param)
        {
            view = param;
            param.controller = this;
        }

        public void Dispatch(Message param)
        {
            view.OnMessage(param);
        }
    }
}

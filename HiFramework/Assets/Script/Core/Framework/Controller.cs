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

        public void Bind(View param)
        {
            view = param;
        }

        public void Dispatch(Message param)
        {
            view.OnMessage(param);
        }
    }
}

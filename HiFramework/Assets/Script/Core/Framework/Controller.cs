﻿//****************************************************************************
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
        /// <summary>
        /// dispath message to view
        /// </summary>
        /// <param name="param"></param>
        public void Dispatch(Message param)
        {
            if (view == null)
                throw new Exception("cannt find its bind view");
            view.OnMessage(param);
        }
    }
}

//****************************************************************************
// Description:ui控制逻辑
// Author: hiramtan@live.com
//****************************************************************************
using System;
namespace HiFramework
{
    public abstract class ViewAgent : Agent
    {
        private View view;

        public void Bind(View view)
        {
            this.view = view;
        }
        /// <summary>
        /// dispath message to view
        /// </summary>
        /// <param name="param"></param>
        public void Dispatch(IMessage param)
        {
            if (view == null)
                throw new Exception("cannt find its bind view");
            view.OnMessage(param);
        }
    }
}

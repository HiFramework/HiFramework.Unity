//****************************************************************************
// Description:与ui绑定的控制逻辑
// Author: hiramtan@live.com
//****************************************************************************
using System;
namespace HiFramework
{
    public abstract class ViewAgent : Agent
    {
        private View _view;

        public void Bind(View view)
        {
            this._view = view;
        }
        /// <summary>
        /// dispath message to view
        /// </summary>
        /// <param name="param"></param>
        public void Dispatch(IMessage param)
        {
            if (_view == null)
                throw new Exception("cannt find its bind view");
            _view.OnMessage(param);
        }
    }
}

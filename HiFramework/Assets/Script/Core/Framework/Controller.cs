//****************************************************************************
// Description:ui控制逻辑
// Author: hiramtan@qq.com
//****************************************************************************
using System;
namespace HiFramework
{
    public abstract class Controller : IController, ITick
    {
        private IView view;

        public void Bind(IView param)
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

        public abstract void OnMessage(Message paramMessage);
        public void AddToTickList(ITick paramTick)
        {
            Facade.GameTick.AddToTickList(paramTick);
        }
        public void RemoveFromTickList(ITick paramTick)
        {
            Facade.GameTick.AddToTickList(paramTick);
        }

        public void OnTick()
        {
            throw new NotImplementedException();
        }
    }
}

//****************************************************************************
// Description: 实例对象,register维护
// Author: hiramtan@live.com
//****************************************************************************

namespace HiFramework
{
    public abstract class Agent : ObjectBase, IRegistAndDispatch, IReceive, ITick
    {
        public object Regist<T>(object paramKey) where T : Agent
        {
            return Facade.IRegistAndDispatch.Regist<T>(paramKey);
        }
        public void Unregist(object paramKey)
        {
            Facade.IRegistAndDispatch.Unregist(paramKey);
        }

        public void Dispatch(object paramKey, IMessage paramMessage = null)
        {
            Facade.IRegistAndDispatch.Dispatch(paramKey, paramMessage);
        }
        public abstract void OnMessage(IMessage paramMessage);

        public void AddToTickList(ITick param)
        {
            Facade.GameTick.AddToTickList(param);
        }

        public void RemoveFromTickList(ITick param)
        {
            Facade.GameTick.RemoveFromTickList(param);
        }

        public abstract void OnTick();

        protected override void OnDispose()
        {

        }
    }
}
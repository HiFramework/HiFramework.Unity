//****************************************************************************
// Description: 实例对象,register维护
// Author: hiramtan@live.com
//****************************************************************************

namespace HiFramework
{
    public abstract class Agent : ObjectBase, IRegistAndDispatch, IReceive, ITick
    {
        public object Regist<T>(object key) where T : Agent
        {
            return Facade.RegistAndDispatch.Regist<T>(key);
        }
        public void Unregist(object key)
        {
            Facade.RegistAndDispatch.Unregist(key);
        }

        public void Dispatch(object key, IMessage message = null)
        {
            Facade.RegistAndDispatch.Dispatch(key, message);
        }

        public virtual void OnMessage(IMessage message)
        {
        }

        public void AddToTickList(ITick iTick)
        {
            Facade.GameTick.AddToTickList(iTick);
        }

        public void RemoveFromTickList(ITick iTick)
        {
            Facade.GameTick.RemoveFromTickList(iTick);
        }

        public virtual void OnTick()
        {
        }

        protected override void OnDispose()
        {

        }
    }
}
//****************************************************************************
// Description: 实例对象,register维护
// Author: hiramtan@live.com
//****************************************************************************

namespace HiFramework
{
    public abstract class Agent : ObjectBase, IRegist, IDispatch, IReceive
    {
        public object Regist<T>(object paramKey) where T : Agent
        {
            return Facade.IRegister.Regist<T>(paramKey);
        }
        public void Unregist(object paramKey)
        {
            Facade.IRegister.Unregist(paramKey);
        }

        public void Dispatch(object paramKey, Message paramMessage = null)
        {
            Facade.IRegister.Dispatch(paramKey, paramMessage);
        }
        public abstract void OnMessage(Message paramMessage);

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
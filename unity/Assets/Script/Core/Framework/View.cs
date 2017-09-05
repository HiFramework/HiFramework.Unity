//****************************************************************************
// Description:view可以有对应控制器,也可以没有.可以直接注册agent
// 但是仍旧是:控制前,agent不对表现层的view直接引用,而是采用派发消息的方式
// Author: hiramtan@live.com
//****************************************************************************

namespace HiFramework
{
    public abstract class View : ObjectBaseMono, IReceive, IRegistAndDispatch, ITick
    {
        public ViewAgent Bind<T>() where T : ViewAgent, new()
        {
            var viewAgent = new T();
            viewAgent.Bind(this);
            return viewAgent;
        }
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
        //接收来自对应控制器和Agent的消息
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
    }
}
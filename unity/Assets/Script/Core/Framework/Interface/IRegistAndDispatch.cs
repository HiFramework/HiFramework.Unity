//****************************************************************************
// Description:
// Author: hiramtan@live.com
//***************************************************************************

namespace HiFramework
{
    public interface IRegistAndDispatch
    {
        object Regist<T>(object key) where T : Agent;

        void Unregist(object key);

        void Dispatch(object key, IMessage message = null);
    }
}
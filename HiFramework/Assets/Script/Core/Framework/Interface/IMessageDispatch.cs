//****************************************************************************
// Description:
// Author: hiramtan@qq.com
//****************************************************************************
namespace HiFramework
{
    public interface IMessageDispatch
    {
        void Dispatch(object paramKey, Message paramMessage = null);
    }
}
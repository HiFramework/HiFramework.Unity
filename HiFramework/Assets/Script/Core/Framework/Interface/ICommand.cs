//****************************************************************************
// Description:
// Author: hiramtan@qq.com
//****************************************************************************
namespace HiFramework
{
    public interface ICommand : IMessageDispatch
    {
        void Register<T>(object paramKey) where T : ILogic;
        void Unregister(object paramKey);
    }
}

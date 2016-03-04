//****************************************************************************
// Description:
// Author: hiramtan@qq.com
//****************************************************************************
namespace HiFramework
{
    public interface ICommand : IMessageDispatch
    {
        void Register<T>(object paramKey) where T : IController;
        void Unregister(object paramKey);
    }
}

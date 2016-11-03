//****************************************************************************
// Description:
// Author: hiramtan@qq.com
//****************************************************************************
namespace HiFramework
{
    public interface ICommand
    {
        object Register<T>(object paramKey) where T : IAgent;
        void Unregister(object paramKey);
    }
}

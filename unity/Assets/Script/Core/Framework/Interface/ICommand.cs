//****************************************************************************
// Description:
// Author: hiramtan@live.com
//****************************************************************************
namespace HiFramework
{
    public interface ICommand
    {
        object Register<T>(object paramKey) where T : IAgent;
        void Unregister(object paramKey);
    }
}

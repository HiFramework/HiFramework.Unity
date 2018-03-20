//****************************************************************************
// Description:
// Author: hiramtan@live.com
//****************************************************************************
namespace HiFramework
{
    public interface IAsyncComponent
    {
        void RegistTick(ITick iTick);
        void UnRegistTick(ITick iTick);
    }
}

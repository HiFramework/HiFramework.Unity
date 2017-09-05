//****************************************************************************
// Description:
// Author: hiramtan@live.com
//****************************************************************************
namespace HiFramework
{
    public interface ITick
    {
        void AddToTickList(ITick iTick);
        void RemoveFromTickList(ITick iTick);
        void OnTick();
    }
}
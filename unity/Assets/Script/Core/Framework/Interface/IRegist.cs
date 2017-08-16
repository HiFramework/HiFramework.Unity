//****************************************************************************
// Description:
// Author: hiramtan@live.com
//***************************************************************************
namespace HiFramework
{
    public interface IRegist
    {
        object Regist<T>(object key) where T : Agent;

        void Unregist(object key);
    }
}

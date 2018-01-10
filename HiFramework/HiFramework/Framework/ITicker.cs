//****************************************************************************
// Description:
// Author: hiramtan@live.com
//****************************************************************************


namespace HiFramework
{
    interface ITicker : ITick
    {
        void Regist<T>(T t) where T : class, ITick;
        void UnRegist<T>(T t) where T : class, ITick;
    }
}

//****************************************************************************
// Description:
// Author: hiramtan@live.com
//****************************************************************************


namespace HiFramework
{
    public interface IBinding
    {
        IBinding Bind<T>();
        IBinding To<T>();
        IBinding ToValue(object obj);
    }
}

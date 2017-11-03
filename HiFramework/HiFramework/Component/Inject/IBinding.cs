﻿//****************************************************************************
// Description:
// Author: hiramtan@qq.com
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
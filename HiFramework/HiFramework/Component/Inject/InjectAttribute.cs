//****************************************************************************
// Description:
// Author: hiramtan@live.com
//****************************************************************************

using System;

namespace HiFramework
{
    [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.Field)]
    class InjectAttribute : Attribute
    {
    }


   
}

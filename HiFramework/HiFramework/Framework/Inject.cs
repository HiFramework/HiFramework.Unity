//****************************************************************************
// Description:
// Author: hiramtan@qq.com
//***************************************************************************
using System;

namespace HiFramework
{
    [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.Field)]
    public class InjectAttribute : Attribute
    {
    }
}

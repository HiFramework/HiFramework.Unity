//****************************************************************************
// Description:
// Author: hiramtan@live.com
//****************************************************************************

using System;

namespace HiFramework
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class InjectAttribute : Attribute
    {
        public string AsName { get; private set; }
        public InjectAttribute()
        {

        }
        public InjectAttribute(string asName)
        {
            AsName = asName;
        }
    }
}

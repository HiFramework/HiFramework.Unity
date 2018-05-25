/****************************************************************************
* Description:
*
* Author: hiramtan @live.com
****************************************************************************/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HiFramework
{
    class BindInfo : IBindInfo
    {
        public Type Type { get; private set; }
        public object ToObj { get; private set; }
        public string AsName { get; private set; }

        public BindInfo(Type type,object toObj,string asName)
        {
            Type = type;
            ToObj = toObj;
            AsName = asName;
        }
    }
}

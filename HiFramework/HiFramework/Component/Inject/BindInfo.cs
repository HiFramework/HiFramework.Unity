/****************************************************************
 * Description: 
 * 
 * Author: hiramtan@live.com
 *////////////////////////////////////////////////////////////////////////



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HiFramework
{
    class BindInfo : IBindInfo
    {
        public Type Type { get; }
        public object ToObj { get; }
        public string AsName { get; }

        public BindInfo(Type type,object toObj,string asName)
        {
            Type = type;
            ToObj = toObj;
            AsName = asName;
        }
    }
}

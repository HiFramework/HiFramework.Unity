//****************************************************************************
// Description:类型可以绑定多个对象,比如接口分别被不同的对象实现
// 如果绑定多个,通过key来区分
// Author: hiramtan@live.com
//****************************************************************************

using System;
using System.Collections.Generic;

namespace HiFramework
{
    public class BindContainer
    {
        Dictionary<Type, List<BindingInfo>> bindInfos = new Dictionary<Type, List<BindingInfo>>();

        public void AsInstance()
        {

        }

        public void SetBindInfo(BindingInfo info)
        {
            if (info.eBindType == BindingInfo.EBindType.Type)
            {

            }
            else
            {

            }
        }
    }
}
//****************************************************************************
// Description:断言
// Author: hiramtan@qq.com
//***************************************************************************

using System;

namespace HiFramework
{
    internal static class Assert
    {
        public static void IsNull(object obj)
        {
            if (obj != null)
                throw new Exception("obj is not null");
        }

        public static void IsNotNull(object obj)
        {
            if (obj == null)
                throw new Exception("obj is null");
        }
    }
}
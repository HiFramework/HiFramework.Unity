//****************************************************************************
// Description:
// Author: hiramtan@qq.com
//***************************************************************************
using System;

namespace HiFramework
{
    internal static class Assert
    {
        public static void IsNull(Object obj)
        {
            if (obj != null)
                throw new Exception("obj is not null");
        }

        public static void IsNotNull(Object obj)
        {
            if (obj == null)
                throw new Exception("obj is null");
        }
    }
}

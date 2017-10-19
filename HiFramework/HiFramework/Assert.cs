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

        public static void IsEqual(object o1, object o2)
        {
            if (o1 != o2)
                throw new Exception("not equal");
        }
        public static void IsNotEqual(object o1, object o2)
        {
            if (o1 == o2)
                throw new Exception("equal");
        }
    }
}
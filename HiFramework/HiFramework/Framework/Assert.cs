//****************************************************************************
// Description:断言
// Author: hiramtan@live.com
//****************************************************************************

using System;

namespace HiFramework
{
    internal static class Assert
    {
        public static void IsNull(object obj)
        {
            if (obj != null)
                throw new Exception("obj is not null:"+obj);
        }

        public static void IsNotNull(object obj)
        {
            if (obj == null)
                throw new Exception("obj is null:"+obj);
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

        public static void IsTrue(bool value)
        {
            if (!value)
                throw new Exception("is not true");
        }

        public static void IsFalse(bool value)
        {
            if (value)
                throw new Exception("is true");
        }

        public static void Exception(string s)
        {
            throw new Exception(s);
        }
    }
}
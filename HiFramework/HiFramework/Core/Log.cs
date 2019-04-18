using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HiFramework
{
    public static class Log
    {
        public static bool IsDebugOn;
        public static bool IsWanningOn;
        public static bool IsErrorOn;

        public static void SetLogger()
        {
        }

        public static void Print(params object[] obj)
        {
            Console.WriteLine(obj);
        }

        public static void Wanning(params object[] obj)
        {
            Console.WriteLine(obj);
        }

        public static void Error(params object[] obj)
        {
            for (int i = 0; i < obj.Length; i++)
            {
                throw new Exception(obj[i].ToString());
            }
        }
    }
}
///****************************************************************************
// * Description:Common log processer
// *
// * Author: hiramtan@live.com
// ****************************************************************************/

//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Text;

//namespace HiFramework
//{
//    public static class Log
//    {
//        public static bool IsDebugOn;
//        public static bool IsWanningOn;
//        public static bool IsErrorOn;

//        public static void Print(params object[] obj)
//        {
//#if VISUAL
//            Console.WriteLine(obj);
//#else

//#endif
//        }

//        public static void Wanning(params object[] obj)
//        {
//#if VISUAL
//            Console.WriteLine(obj);
//#else

//#endif
//        }

//        public static void Error(params object[] obj)
//        {
//#if VISUAL
//            for (int i = 0; i < obj.Length; i++)
//            {
//                throw new Exception(obj[i].ToString());
//            }
//#else

//#endif
//        }
//    }
//}
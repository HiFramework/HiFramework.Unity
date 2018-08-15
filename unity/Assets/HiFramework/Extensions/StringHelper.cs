/****************************************************************************
 * Description:
 *
 * Author: hiramtan@live.com
 ****************************************************************************/

using System;
using System.Text;

namespace HiFramework
{
    public static class StringHelper
    {
        /// <summary>
        /// 格式化字符串
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static string Format(string info)
        {
            if (string.IsNullOrEmpty(info))
            {
                throw new ArgumentNullException("info is null or empty");
            }
            return string.Format("[{0}]", info);
        }

        /// <summary>
        /// 拼接字符串
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string Append(params string[] args)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < args.Length; i++)
            {
                sb.Append(args[i]);
            }
            return sb.ToString();
        }
    }
}
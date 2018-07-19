/****************************************************************************
 * Description:
 *
 * Author: hiramtan@live.com
 ****************************************************************************/

using System;

namespace HiFramework
{
    public class StringComponent : Component
    {
        public static string FormatInfo(string info)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info is null");
            }
            return string.Format("[{0}]", info);
        }
    }
}
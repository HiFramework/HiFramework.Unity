/***************************************************************
 * Description: 
 *
 * Documents: 
 * Author: hiramtan@live.com
***************************************************************/

using System;

namespace HiFramework
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class InjectAttribute : Attribute
    {
        /// <summary>
        /// Find bindinfo's AsName
        /// </summary>
        public string AsName { get; private set; }

        /// <summary>
        /// Default is no AsName
        /// </summary>
        public InjectAttribute()
        {

        }

        /// <summary>
        /// Set AsName
        /// </summary>
        /// <param name="asName"></param>
        public InjectAttribute(string asName)
        {
            AsName = asName;
        }
    }
}

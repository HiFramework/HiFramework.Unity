/***************************************************************
 * Description: 
 *
 * Documents: 
 * Author: hiramtan@live.com
***************************************************************/

using System;
using System.Collections.Generic;

namespace HiFramework
{
    /// <summary>
    /// 绑定信息维护
    /// </summary>
    internal class InjectBindInfoContainer
    {
        /// <summary>
        /// Bindinfos 
        /// </summary>
        private List<InjectBindInfo> bindInfos = new List<InjectBindInfo>();

        /// <summary>
        /// 添加绑定信息
        /// </summary>
        /// <param name="bindInfo"></param>
        public void Add(InjectBindInfo bindInfo)
        {
            bindInfos.Add(bindInfo);
        }

        /// <summary>
        /// Get object with type and AsName
        /// </summary>
        /// <param name="type"></param>
        /// <param name="asName"></param>
        /// <returns></returns>
        public InjectBindInfo GetBindInfo(Type type, string asName)
        {
            return bindInfos.Find((x) => { return (x.Type == type && x.AsName == asName); });
        }
    }
}

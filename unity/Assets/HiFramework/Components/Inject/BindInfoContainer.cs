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
    public class BindInfoContainer
    {
        /// <summary>
        /// Bindinfos 
        /// </summary>
        private List<BindInfo> bindInfos = new List<BindInfo>();

        /// <summary>
        /// 添加绑定信息
        /// </summary>
        /// <param name="bindInfo"></param>
        public void Add(BindInfo bindInfo)
        {
            bindInfos.Add(bindInfo);
        }

        /// <summary>
        /// Get object with type and AsName
        /// </summary>
        /// <param name="type"></param>
        /// <param name="asName"></param>
        /// <returns></returns>
        public BindInfo GetBindInfo(Type type, string asName)
        {
            return bindInfos.Find((x) => { return (x.Type == type && x.AsName == asName); });
        }
    }
}

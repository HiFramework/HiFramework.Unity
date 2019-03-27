/***************************************************************
 * Description: 
 *
 * Documents: 
 * Author: hiramtan@live.com
***************************************************************/

using System;

namespace HiFramework
{
    abstract class ActionBase
    {
        /// <summary>
        /// 派发事件
        /// </summary>
        /// <param name="objects">回调参数</param>
        public abstract void Dispatch(params object[] objects);

        /// <summary>
        /// 参数不匹配
        /// </summary>
        protected void ParamMatchError()
        {
            throw new Exception("Param can not match");
        }
    }
}

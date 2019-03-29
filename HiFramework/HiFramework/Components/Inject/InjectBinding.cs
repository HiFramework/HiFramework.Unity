/***************************************************************
 * Description: 
 *
 * Documents: 
 * Author: hiramtan@live.com
***************************************************************/

using System;

namespace HiFramework
{
    /// <summary>
    /// 正在执行绑定对象
    /// </summary>
    public class InjectBinding 
    {
        /// <summary>
        /// 绑定to结束后的相应回调
        /// </summary>
        private Action<InjectBindInfo> BindToFinishHandler;

        /// <summary>
        /// 绑定信息
        /// </summary>
        private InjectBindInfo bindInfo = new InjectBindInfo();

        /// <summary>
        /// 构造函数，绑定类型
        /// </summary>
        /// <param name="type"></param>
        public InjectBinding(Type type, Action<InjectBindInfo> action)
        {
            bindInfo.SetType(type);
            BindToFinishHandler = action;
        }

        /// <summary>
        /// Bind to a instance 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public InjectBindAsName To(object args)
        {
            bindInfo.SetObject(args);
            BindToFinishHandler(bindInfo);
            return new InjectBindAsName(bindInfo);
        }
    }
}

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
    public class Binding : IBinding
    {
        /// <summary>
        /// 绑定to结束后的相应回调
        /// </summary>
        private Action<BindInfo> BindToFinishHandler;

        /// <summary>
        /// 绑定信息
        /// </summary>
        private BindInfo bindInfo = new BindInfo();

        /// <summary>
        /// 构造函数，绑定类型
        /// </summary>
        /// <param name="type"></param>
        public Binding(Type type, Action<BindInfo> action)
        {
            bindInfo.SetType(type);
            BindToFinishHandler = action;
        }

        /// <summary>
        /// Bind to a instance 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public IBindAsName To(object args)
        {
            bindInfo.SetObject(args);
            BindToFinishHandler(bindInfo);
            return new BindAsName(bindInfo);
        }
    }
}

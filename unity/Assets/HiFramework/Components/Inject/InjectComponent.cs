/***************************************************************
 * Description: 
 *
 * Documents: 
 * Author: hiramtan@live.com
***************************************************************/

using System;

namespace HiFramework
{
    public class InjectComponent : IInject
    {
        BindInfoContainer bindInfoContainer = new BindInfoContainer();
        /// <summary>
        /// Bind a type to a instance
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IBinding Bind<T>()
        {
            Type type = typeof(T);
            return new Binding(type, OnBindToFinish);
        }

        /// <summary>
        /// 当绑定实例完成时
        /// </summary>
        /// <param name="bindInfo"></param>
        private void OnBindToFinish(BindInfo bindInfo)
        {
            bindInfoContainer.Add(bindInfo);
        }

        /// <summary>
        /// Inject a instance
        /// Only property and filed for current now
        /// </summary>
        /// <param name="args"></param>
        public void Inject(object args)
        {
            throw new System.NotImplementedException();
        }
    }
}

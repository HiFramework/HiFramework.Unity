//****************************************************************************
// Description:
// Author: hiramtan@live.com
//****************************************************************************

namespace HiFramework
{
   public interface IBinder
    {
        /// <summary>
        /// 执行绑定
        /// </summary>
        void SetUp();
        IBinding Bind<T>();//可以填充多个类型,绑定同一实例

        /// <summary>
        /// 解除对象:通过类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        void UnBind<T>();
        /// <summary>
        /// 解除对象:通过对象实例
        /// </summary>
        /// <param name="obj"></param>
        void UnBind(object obj);

        object GetInstance<T>();
        /// <summary>
        /// 执行注入
        /// 为了不对整体有影响,不强制继承采用手动注入方式
        /// </summary>
        /// <param name="obj"></param>
        void Inject(object obj);
    }
}

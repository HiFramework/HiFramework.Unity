//****************************************************************************
// Description:
// Author: hiramtan@live.com
//****************************************************************************

namespace HiFramework
{
    interface IBinder
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
    }
}

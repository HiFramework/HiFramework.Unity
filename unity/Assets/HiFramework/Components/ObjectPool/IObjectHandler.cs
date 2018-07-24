/***************************************************************
 * Description: 单个对象处理,用户需要继承实现该接口
 * Documents: 
 * Author: hiramtan@live.com
***************************************************************/

namespace HiFramework
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IObjectHandler<T>
    {
        /// <summary>
        /// 创建对象
        /// </summary>
        /// <returns></returns>
        T OnCreate();

        /// <summary>
        /// 对象添加到对象池时
        /// (比如设置隐藏,位置)
        /// </summary>
        /// <param name="t"></param>
        void OnInToPool(T t);

        /// <summary>
        /// 对象从对象池取出时
        /// (比如设置显示)
        /// </summary>
        void OnGetFromPool(T t);

        /// <summary>
        /// 对象销毁时
        /// </summary>
        /// <param name="t"></param>
        void OnDestory(T t);
    }
}
//****************************************************************************
// Description:
// Author: hiramtan@qq.com
//****************************************************************************


namespace HiFramework
{
    public interface IPool<T>
    {
        /// <summary>
        /// 获取对象
        /// </summary>
        /// <returns></returns>
        T Get();
        /// <summary>
        /// 回收对象
        /// </summary>
        /// <param name="args"></param>
        void Reclaim(T args);
        /// <summary>
        /// 删除对象池和所有对象
        /// </summary>
        void Destory();
    }
}
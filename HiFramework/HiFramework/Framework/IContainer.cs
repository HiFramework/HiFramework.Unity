//****************************************************************************
// Description:
// Author: hiramtan@live.com
//****************************************************************************

namespace HiFramework
{
    public interface IContainer
    {
        /// <summary>
        /// 组件注册
        /// </summary>
        /// <param name="obj"></param>
        void Regist(IComponent obj);
        void UnRegist(string key);
        bool HasKey(string key);
        T Get<T>() where T : class, IComponent;
    }
}

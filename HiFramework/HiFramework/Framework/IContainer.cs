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

        void UnRegist<T>() where T : class, IComponent;
         bool HasComPonent<T>() where T : class, IComponent;
        T Get<T>() where T : class, IComponent;
    }
}

/****************************************************************************
* Description: 组件注册,维护逻辑
*
* Author: hiramtan @live.com
****************************************************************************/



namespace HiFramework
{
    public interface IContainer
    {
        void Regist(IComponent iComponent);
        void Unregist(IComponent iComponent);
        T Get<T>() where T : class, IComponent;
        bool IsHave<T>() where T : class, IComponent;
    }
}

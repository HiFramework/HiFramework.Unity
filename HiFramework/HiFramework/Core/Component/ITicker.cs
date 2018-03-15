/****************************************************************************
 * Description:ticker组件
 * 基于组件系统实现,同时tick也作为框架的基础逻辑
 *
 * Author: hiramtan@live.com
 ****************************************************************************/



namespace HiFramework
{
    interface ITicker : ITick
    {
        void Regist(IComponent iComponent);
        void Unregist(IComponent iComponent);
    }
}

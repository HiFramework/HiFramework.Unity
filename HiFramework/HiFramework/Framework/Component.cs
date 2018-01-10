//****************************************************************************
// Description:构造注入:防止用户扩展时无构造函数or构造函数参数不匹配
// Author: hiramtan@live.com
//****************************************************************************


namespace HiFramework
{
    public abstract class Component : IComponent
    {
        public Component(IContainer iContainer)
        {
            iContainer.Regist(this);
        }

        public abstract void UnRegistComponent();
    }
}

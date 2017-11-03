//****************************************************************************
// Description:
// 多个类型可以绑定同一实例,比如子类父类类型同时绑定子类实例
// 一个类型可以绑定多个实例,比如接口可以被多个实例继承,通过key来区分
// Author: hiramtan@qq.com
//****************************************************************************

namespace HiFramework
{
    public class Binder : Component, IBinder
    {
        private BindContainer _bindContainer;

        public Binder(IContainer iContainer) : base(iContainer)
        {
            _bindContainer = new BindContainer();
        }

        public override void UnRegistComponent()
        {
            _bindContainer = null;
        }

        #region 绑定类型
        public IBinding Bind<T>()
        {
            return new Binding(OnBindingInfo);
        }

        private void OnBindingInfo(BindingInfo info)
        {
            _bindContainer.SetBindInfo(info);
        }
        #endregion
    }
}
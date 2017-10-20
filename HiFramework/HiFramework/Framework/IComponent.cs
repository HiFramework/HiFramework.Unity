//****************************************************************************
// Description:组件:可以继承扩展自己or第三方类库
// Author: hiramtan@qq.com
//***************************************************************************

/// <summary>
/// 组件统一接口
/// 组件注册类不允许构造
/// </summary>
namespace HiFramework
{
    public interface IComponent
    {
        void OnRegist();
        void OnUnRegist();
    }
}

//****************************************************************************
// Description:
// Author: hiramtan@qq.com
//***************************************************************************

/// <summary>
/// 组件统一接口
/// 组件注册类不允许构造
/// </summary>
namespace HiFramework
{
    public interface IComponet
    {
        void Regist();
        void UnRegist();
    }
}

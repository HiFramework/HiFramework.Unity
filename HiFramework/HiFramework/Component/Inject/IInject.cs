//****************************************************************************
// Description:
// Author: hiramtan@qq.com
//****************************************************************************

namespace HiFramework
{
    interface IInject
    {
        void Init();
        void Bind();
        void UnBind();
        void GetBind();
        void SetBindInstance(object obj);
    }
}

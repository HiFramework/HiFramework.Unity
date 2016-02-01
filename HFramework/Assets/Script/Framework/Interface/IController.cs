using System;
namespace HFramework
{
    /// <summary>
    /// 业务逻辑必须继承此接口
    /// </summary>
    public interface IController
    {
        void Execute(Message paramMessage);
        void Register(Message paramMessage, Type paramType);

        void Remove(Message paramMessage);
    }
}
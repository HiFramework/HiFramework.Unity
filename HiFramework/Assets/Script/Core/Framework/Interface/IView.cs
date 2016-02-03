using System;
namespace HiFramework
{
    /// <summary>
    /// ui层的逻辑控制
    /// </summary>
    public interface IView : IMessageDispatch, ITick
    {
        void Register<T>(IView paramKey);
        void Remove(IView paramView);
    }
}
//****************************************************************************
// Description:
// Author: hiramtan@live.com
//****************************************************************************
namespace HiFramework
{
    /// <summary>
    /// 表现层控制逻辑
    /// </summary>
    public interface IView : ITick, IReceive
    {
        /// <summary>
        /// bind this view to its controller
        /// </summary>
        /// <typeparam name="T"></typeparam>
        IController Bind<T>() where T : IController, new();
    }
}

namespace HFramework
{
    /// <summary>
    /// 界面层(与之交互的是mediator)
    /// </summary>
    public interface IView
    {
        void OnMessage(Message paramMessage);
    }
}

namespace HFramework
{
    /// <summary>
    /// ui层的逻辑控制
    /// </summary>
    public interface IView : IMessage
    {
        void Register(IView paramView, Controller paramController);
    }
}
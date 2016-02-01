
namespace HFramework
{
    /// <summary>
    /// ui层的逻辑控制
    /// </summary>
    public interface IView
    {
        void Register(IView paramView, IController paramController);
    }
}
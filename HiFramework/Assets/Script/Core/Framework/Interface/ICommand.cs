namespace HiFramework
{
    public interface ICommand : IMessageDispatch
    {
        void Register<T>(object paramKey) where T : IController;
        void Remove(object paramKey);
    }
}

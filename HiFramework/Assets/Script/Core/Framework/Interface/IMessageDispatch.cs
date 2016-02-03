


namespace HiFramework
{
    public interface IMessageDispatch
    {
        void Dispatch<T>(T paramKey, Message paramMessage);
    }
}
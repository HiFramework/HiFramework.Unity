namespace HiFramework
{
    interface ITickComponent : ITick
    {
        void Regist<T>(T t) where T : ITick, new();

        void Unregist<T>(T t) where T : ITick, new();
    }
}

namespace HiFramework
{
    interface IAsyncComponent
    {
        void RegistTick(ITick iTick);
        void UnRegistTick(ITick iTick);
    }
}

namespace HiFramework
{
    public class BindInfo<T>
    {
        private readonly Binder _binder;
        internal BindInfo(Binder binder)
        {
            _binder = binder;
        }

        public void To<U>() where U : Component, new()
        {
            var key = typeof(T);
            var instance = typeof(U);
            _binder.SetKeyAndInstance(key, instance);
        }
    }
}

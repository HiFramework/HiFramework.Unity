/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiFramework_unity
 * Author: hiramtan@live.com
 ****************************************************************************/
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
            var component = typeof(U);
            _binder.SetKeyAndComponent(key, component);
        }
    }
}

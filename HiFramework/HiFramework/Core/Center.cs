//---------------------------------------------------------------------------------------------------
/*Description: 框架使用过程中外部接口
 * 
 * 
 * Author: hiramtan@live.com
 */
//---------------------------------------------------------------------------------------------------




namespace HiFramework
{
    class Center : IFramework
    {
        static IContainer _iContainer = new Container();
        private static ITicker _iTicker;
        public static T Get<T>() where T : class, IComponent
        {
            var c = _iContainer.Get<T>();
            _iTicker.Regist(c);
            return c;
        }

        public static bool IsHave<T>() where T : class, IComponent
        {
            return _iContainer.IsHave<T>();
        }

        public static void Remove<T>() where T : class, IComponent
        {
            var c = _iContainer.Get<T>();
            _iTicker.Unregist(c);
            _iContainer.Unregist(c);
        }


        public void Init()
        {
            //don't use Center.Get because this api will use ticker judge tick and at this time ticker is still null.
            _iTicker = _iContainer.Get<Ticker>();
        }

        public void Tick()
        {
            _iTicker.Tick();
        }
    }
}

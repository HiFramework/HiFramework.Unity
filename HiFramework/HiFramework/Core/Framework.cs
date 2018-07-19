/****************************************************************************
 * Description: Framework Entry
 *
 * Author: hiramtan@live.com
 ****************************************************************************/
namespace HiFramework
{
    public static class Framework
    {
        /// <summary>
        /// Enter to achieve IFramework interface and center logic
        /// </summary>
        private static IFramework center;

        /// <summary>
        /// Init framework
        /// </summary>
        public static void Init()
        {
            AssertThat.IsNull(center);
            center = new Center();
            center.Init();
        }

        /// <summary>
        /// Tick all component
        /// </summary>
        public static void Tick()
        {
            AssertThat.IsNotNull(center);
            center.Tick();
        }

        /// <summary>
        /// Destory framework(destory every component)
        /// </summary>
        public static void Destory()
        {
            AssertThat.IsNotNull(center);
            center.Destory();
        }
    }
}

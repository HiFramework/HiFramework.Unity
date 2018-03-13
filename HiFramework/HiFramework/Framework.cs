//---------------------------------------------------------------------------------------------------
/*Description: 
 * 
 * 
 * Author: hiramtan@live.com
 */
//---------------------------------------------------------------------------------------------------

namespace HiFramework
{
    public static class Framework
    {
        private static IFramework iFramework;
        public static void Init()
        {
            Assert.IsNull(iFramework);
            iFramework = new Center();
            iFramework.Init();
        }

        public static void Tick()
        {
            Assert.IsNotNull(iFramework);
            iFramework.Tick();
        }
    }
}

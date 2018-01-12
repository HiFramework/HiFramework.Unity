/*
 * Description: hidebug's view logic
 * 
 * Author: hiramtan@live.com
 */


namespace HiFramework
{
    class TestBind
    {
        void Start()
        {
           var binder =  Center.Get<Binder>();

            binder.Bind<Test1>().To<Test2>().AsName("");
            binder.Bind<Test1>().Bind<Test2>().To<Test2>().AsName("");
        }
    }

    public class Test1 { }
    public class Test2 { }
}

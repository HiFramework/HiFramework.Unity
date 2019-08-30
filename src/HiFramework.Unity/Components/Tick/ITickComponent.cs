/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiFramework.Unity
 * Author: hiramtan@live.com
 ****************************************************************************/
namespace HiFramework.Unity
{
    public interface ITickComponent : ITick
    {
        void Regist<T>(T t) where T : ITick;

        void Unregist<T>(T t) where T : ITick;
    }
}

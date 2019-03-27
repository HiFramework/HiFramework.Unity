/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiFramework_unity
 * Author: hiramtan@live.com
 ****************************************************************************/
namespace HiFramework
{
    public interface ITickComponent : ITick
    {
        void Regist<T>(T t) where T : ITick, new();

        void Unregist<T>(T t) where T : ITick, new();
    }
}

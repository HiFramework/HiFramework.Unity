///****************************************************************************
// * Description:Common log processer
// *
// * Author: hiramtan@live.com
// ****************************************************************************/
namespace HiFramework
{
    public interface ILogProxy
    {
        void Print(params object[] args);
        void Warnning(params object[] args);
        void Error(params object[] args);
    }
}
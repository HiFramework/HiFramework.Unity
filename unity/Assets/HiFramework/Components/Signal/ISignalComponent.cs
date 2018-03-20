/****************************************************************************
 * Description:
 *
 * Author: hiramtan@live.com
 ****************************************************************************/

namespace HiFramework
{
    public interface ISignalComponent
    {
        /// <summary>
        /// 注册事件
        /// </summary>
        /// <param name="key"></param>
        /// <param name="iSignal"></param>
        void AddSignal(SignalBase iSignal);

        /// <summary>
        /// 移除事件
        /// </summary>
        /// <param name="iSignal"></param>
        void RemoveSignal(SignalBase iSignal);
    }
}

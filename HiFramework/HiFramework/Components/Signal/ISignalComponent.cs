//---------------------------------------------------------------------------------------------------
/*Description: 
 * 
 * 
 * Author: hiramtan@live.com
 */
//---------------------------------------------------------------------------------------------------

namespace HiFramework
{
    public interface ISignalComponent
    {
        /// <summary>
        /// 注册事件
        /// </summary>
        /// <param name="key"></param>
        /// <param name="iSignal"></param>
        void AddSignal(string key, SignalBase iSignal);

        /// <summary>
        /// 获取事件
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        SignalBase GetSignal(string key);
        /// <summary>
        /// 移除事件
        /// </summary>
        /// <param name="iSignal"></param>
        void RemoveSignal(string key);
    }
}

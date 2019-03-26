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
        /// Add signal to container
        /// </summary>
        /// <param name="key"></param>
        /// <param name="signal"></param>
        void AddSignal(string key, SignalBase signal);

        /// <summary>
        /// Remove signal from container
        /// </summary>
        /// <param name="key"></param>
        void RemoveSignal(string key);

        /// <summary>
        /// Get signal
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        SignalBase GetSignal(string key);
    }
}

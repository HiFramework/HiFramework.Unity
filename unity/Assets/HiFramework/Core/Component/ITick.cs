/****************************************************************************
* Description: If component want to have tick function should inherited from this interface
*
* Author: hiramtan @live.com
****************************************************************************/

namespace HiFramework
{
    /// <summary>
    /// Tick interface
    /// </summary>
    public interface ITick
    {
        /// <summary>
        /// Tick method to run all tick components
        /// </summary>
        void Tick();
    }
}
/****************************************************************************
* Description: If component want to have tick function should inherited from this interface
*
 * Document: https://github.com/hiramtan/HiFramework_unity
 * Author: hiramtan@live.com
 ****************************************************************************/

namespace HiFramework
{
    /// <summary>
    /// Tick interface
    /// </summary>
    public interface ITick
    {
        /// <summary>
        /// Tick method to run all tick Components
        /// </summary>
        void Tick(float deltaTime);
    }
}
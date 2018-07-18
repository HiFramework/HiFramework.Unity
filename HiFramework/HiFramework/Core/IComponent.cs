/****************************************************************************
* Description: 
*
* Author: hiramtan @live.com
****************************************************************************/

namespace HiFramework
{
    public interface IComponent
    {
        /// <summary>
        /// When component created
        /// </summary>
        void OnCreated();

        /// <summary>
        /// When component removed
        /// </summary>
        void OnDestory();
    }
}

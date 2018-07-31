/****************************************************************************
* Description: 
* 
 * Document: https://github.com/hiramtan/HiFramework_unity
 * Author: hiramtan@live.com
 ****************************************************************************/

using System;

namespace HiFramework
{
    public interface IComponent : IDisposable
    {
        /// <summary>
        /// When component created
        /// </summary>
        void OnCreated();
    }
}

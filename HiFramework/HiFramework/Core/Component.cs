/****************************************************************************
 * Description: Base class of component
 * Componet must inherit from this
 * 
 * Author: hiramtan@live.com
 ****************************************************************************/
namespace HiFramework
{
    /// <summary>
    /// Component base class
    /// </summary>
    public abstract class Component : IComponent
    {
        /// <summary>
        /// When this component created
        /// </summary>
        public abstract void OnCreated();

        /// <summary>
        /// When this component removed
        /// </summary>
        public abstract void OnRemoved();
    }
}
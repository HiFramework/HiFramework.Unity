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
        private TickComponent tickComponent;
        /// <summary>
        /// When this component created
        /// </summary>
        public virtual void OnCreated()
        {
            tickComponent = Center.Get<TickComponent>();
            tickComponent.Regist(this);
        }

        /// <summary>
        /// When this component removed
        /// </summary>
        public virtual void OnDestory()
        {
            tickComponent.Unregist(this);
        }
    }
}
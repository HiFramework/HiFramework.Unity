/****************************************************************************
 * Description: Base class of component
 * Componet must inherit from this
 * 
 * Document: https://github.com/hiramtan/HiFramework_unity
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
        /// Framework's tick component
        /// </summary>
        private TickComponent _tickComponent;

        /// <summary>
        /// When this component created
        /// </summary>
        public virtual void OnCreated()
        {
            _tickComponent = Center.Get<TickComponent>();
            _tickComponent.Regist(this);
        }

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public virtual void Dispose()
        {
            _tickComponent.Unregist(this);
        }
    }
}
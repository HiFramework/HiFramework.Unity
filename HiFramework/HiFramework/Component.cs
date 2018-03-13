//---------------------------------------------------------------------------------------------------
/*Description: 组件必须继承此类
 * 
 * 
 * Author: hiramtan@live.com
 */
//---------------------------------------------------------------------------------------------------

namespace HiFramework
{
    public abstract class Component : IComponent
    {
        public Component(IContainer iContainer)
        {
            iContainer.Regist(this);
        }

        /// <summary>
        /// 组件创建时
        /// </summary>
        public abstract void OnInit();

        /// <summary>
        /// 组件销毁时
        /// </summary>
        public abstract void OnClose();
    }
}

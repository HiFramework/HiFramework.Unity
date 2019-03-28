/***************************************************************
 * Description: 
 *
 * Documents: 
 * Author: hiramtan@live.com
***************************************************************/

namespace HiFramework
{
    public class BindAsName
    {
        /// <summary>
        /// 绑定信息
        /// </summary>
        private InjectBindInfo bindInfo;

        /// <summary>
        /// 构造函数，绑定信息
        /// </summary>
        /// <param name="bindInfo"></param>
        public BindAsName(InjectBindInfo bindInfo)
        {
            this.bindInfo = bindInfo;
        }

        /// <summary>
        /// This interface is opertional
        /// Bind type to a instance with a name
        /// </summary>
        /// <param name="name"></param>
        public void AsName(string name)
        {
            bindInfo.SetAsName(name);
        }
    }
}

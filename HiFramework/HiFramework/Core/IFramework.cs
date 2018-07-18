/****************************************************************************
 * Description: Framework main entry
 *
 * Author: hiramtan@live.com
 ****************************************************************************/
namespace HiFramework
{
    internal interface IFramework
    {
        /// <summary>
        /// Init framework
        /// </summary>
        void Init();

        /// <summary>
        /// Tick all component
        /// </summary>
        void Tick();

        /// <summary>
        /// Destory framework(destory every component)
        /// </summary>
        void Destory();
    }
}

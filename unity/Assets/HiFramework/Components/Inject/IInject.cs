/***************************************************************
 * Description: 
 *
 * Documents: 
 * Author: hiramtan@live.com
***************************************************************/

namespace HiFramework
{
    public interface IInject
    {
        /// <summary>
        /// Bind a type to a instance
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IBinding Bind<T>();

        /// <summary>
        /// Inject a instance
        /// Only property and filed for current now
        /// </summary>
        /// <param name="args"></param>
        void Inject(object args);
    }
}

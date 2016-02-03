using UnityEngine;
using System.Collections;
namespace HiFramework
{
    public interface IController : IMessageDispatch
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">value</typeparam>
        /// <param name="paramKey">key</param>
        void Register<T>(string paramKey) where T :IController;
        void Remove(string paramKey);
    }
}
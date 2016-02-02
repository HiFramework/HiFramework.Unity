using UnityEngine;
using System.Collections;
namespace HiFramework
{
    public interface IController : IMessageDispatch
    {
        void Register<T>(string paramKey);
        void Remove(string paramKey);
    }
}
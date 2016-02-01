using UnityEngine;
using System.Collections;



namespace HFramework
{
    public interface IController : IMessage
    {
        void Register();
        void Remove();
    }
}
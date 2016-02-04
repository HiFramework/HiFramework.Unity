using UnityEngine;
using System.Collections;

using System;

namespace HiFramework
{
    public interface IController : ICommand, IMessage, IDisposable
    {

    }
}
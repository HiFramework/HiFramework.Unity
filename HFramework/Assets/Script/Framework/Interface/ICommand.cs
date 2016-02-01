using UnityEngine;
using System.Collections;

namespace HFramework
{
    /// <summary>
    /// 控制逻辑必须继承
    /// </summary>
    public interface ICommand
    {
        void Execute(Message paramMessage);
    }
}

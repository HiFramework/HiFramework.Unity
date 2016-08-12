//*********************************************************************
// Description:
// Author: hiramtan@live.com
//*********************************************************************
using UnityEngine;
using System.Collections;

namespace HiFramework
{
    public interface IMessageReceive
    {
        void OnMessage(Message paramMessage);
    }
}

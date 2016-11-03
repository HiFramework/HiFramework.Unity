//*********************************************************************
// Description:
// Author: hiramtan@live.com
//*********************************************************************
using UnityEngine;
using System.Collections;

namespace HiFramework
{

    public interface IFacade
    {
        void Dispatch(object paramKey, Message paramMessage);
    }

}

/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiFramework.Unity
 * Author: hiramtan@live.com
 ****************************************************************************/
 
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HiFramework.Unity
{
    public interface IStateRule
    {
        bool IsCanChangeState(IState current, IState next);
    }
}

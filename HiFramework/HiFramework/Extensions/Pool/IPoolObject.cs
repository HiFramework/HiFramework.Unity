/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiFramework_unity
 * Author: hiramtan@live.com
 ****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HiFramework
{
    public interface IPoolObject
    {
        void OnObjectCreate();
        void OnObjectDispose();
        void OnObjectInPool();
        void OnObjectOutPool();
    }
}

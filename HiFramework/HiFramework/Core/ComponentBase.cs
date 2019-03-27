/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiFramework_unity
 * Author: hiramtan@live.com
 ****************************************************************************/
using System;
namespace HiFramework
{
    public abstract class ComponentBase : IDisposable
    {
        public abstract void OnCreated();
        public abstract void Dispose();
    }
}

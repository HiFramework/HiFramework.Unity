/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiFramework_unity
 * Author: hiramtan@live.com
 ****************************************************************************/
using System;
namespace HiFramework
{
    public abstract class Component : IDisposable
    {
        public abstract void OnCreated();
        public abstract void Dispose();
    }
}

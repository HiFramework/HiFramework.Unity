/****************************************************************
 * Description: 
 * 
 * Author: hiramtan@live.com
 *////////////////////////////////////////////////////////////////////////



using System;
using System.Collections.Generic;

namespace HiFramework
{
    internal class BindContainer:IBindContainer
    {
        private List<IBinding> _iBindings = new List<IBinding>();
        private List<IBindInfo> _iBindInfos = new List<IBindInfo>();
        public void AddBinding(IBinding iBinding)
        {
           _iBindings.Add(iBinding);
        }

        public void GenerateBindInfo()
        {
            
        }
    }
}

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
        private List<IBinding> types = new List<IBinding>();
        public void AddBinding(IBinding iBinding)
        {
           types.Add(iBinding);
        }

        public void GenerateBindInfo()
        {
            
        }
    }
}

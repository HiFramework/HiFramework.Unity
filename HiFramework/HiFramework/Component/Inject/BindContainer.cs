/****************************************************************
 * Description: 
 * 
 * Author: hiramtan@live.com
 *////////////////////////////////////////////////////////////////////////



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HiFramework
{
    internal class BindContainer:IBindContainer
    {
        private List<IBindInfo> types = new List<IBindInfo>();
        public void AddBinding(IBinding iBinding)
        {
            throw new NotImplementedException();
        }

        public void GenerateBindInfo()
        {
            throw new NotImplementedException();
        }
    }
}

/****************************************************************
 * Description: 
 * 
 * Author: hiramtan@live.com
 *////////////////////////////////////////////////////////////////////////



using System;
using System.Collections.Generic;

namespace HiFramework
{
    internal class BindContainer : IBindContainer
    {
        private List<IBinding> _iBindings = new List<IBinding>();
        private List<IBindInfo> _iBindInfos = new List<IBindInfo>();
        public void AddBinding(IBinding iBinding)
        {
            _iBindings.Add(iBinding);
        }

        public void GenerateBindInfo()
        {
            for (int i = 0; i < _iBindings.Count; i++)
            {
                if (_iBindings[i].ToType != null)
                {
                    ProcessInstance(_iBindings[i]);
                }
                else
                {
                    for (int j = 0; j < _iBindings[i].Types.Count; j++)
                    {
                        IBindInfo iBindInfo = new BindInfo(_iBindings[i].Types[j].GetType(),_iBindings[i].ToObj,_iBindings[i].AsName);
                        _iBindInfos.Add(iBindInfo);
                    }
                }
            }
        }

        private void ProcessInstance(IBinding iBinding)
        {

        }

        object GetObjectFromIBindInfos(Type type)
        {
            return _iBindInfos.Find((x) => { return x.ToObj.GetType() == type; });
        }
    }
}

/****************************************************************
 * Description: 
 * 
 * Author: hiramtan@live.com
 *////////////////////////////////////////////////////////////////////////



using System;
using System.Collections.Generic;
using System.Reflection;

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
                    ProcessObj(_iBindings[i]);
                }
                else
                {
                    for (int j = 0; j < _iBindings[i].Types.Count; j++)
                    {
                        IBindInfo iBindInfo = new BindInfo(_iBindings[i].Types[j].GetType(), _iBindings[i].ToObj, _iBindings[i].AsName);
                        _iBindInfos.Add(iBindInfo);
                    }
                }
            }
            Inject();
        }
        /// <summary>
        /// 构造函数无参数
        /// </summary>
        /// <param name="iBinding"></param>
        private void ProcessObj(IBinding iBinding)
        {
            var obj = Activator.CreateInstance(iBinding.ToType);
            for (int j = 0; j < iBinding.Types.Count; j++)
            {
                IBindInfo iBindInfo = new BindInfo(iBinding.Types[j].GetType(), obj, iBinding.AsName);
                _iBindInfos.Add(iBindInfo);
            }
        }

        private void Inject()
        {
            var types = Assembly.GetExecutingAssembly().GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i].GetInterface(typeof(IInject).FullName) == typeof(IInject))
                {
                    var type = types[i];
                    type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                }
            }
        }


        object GetObjectFromIBindInfos(Type type)
        {
            return _iBindInfos.Find(x => { return x.ToObj.GetType() == type; });
        }
    }
}

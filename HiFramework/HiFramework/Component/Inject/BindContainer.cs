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
                        IBindInfo iBindInfo = new BindInfo(_iBindings[i].Types[j], _iBindings[i].ToObj, _iBindings[i].AsName);
                        _iBindInfos.Add(iBindInfo);
                    }
                }
            }
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

        public void Inject(object obj)
        {
            InjectFields(obj);
            InjectProperty(obj);
        }

        void InjectFields(object obj)
        {
            var type = obj.GetType();
            var fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            for (int i = 0; i < fields.Length; i++)
            {
                var attributes = fields[i].GetCustomAttributes(typeof(InjectAttribute), true);
                if (attributes.Length == 0)//have no inject attribute
                    continue;
                if (attributes.Length > 1)
                {
                    Assert.Exception("multiple inject attribute");
                }
                var injectAttribute = attributes[0] as InjectAttribute;
                var toObj =  GetObjectWithAsNameFromIBindInfos(fields[i].FieldType, injectAttribute.AsName);
                fields[i].SetValue(obj, toObj);
            }
        }

        void InjectProperty(object obj)
        {
            var type = obj.GetType();
            var propertys = type.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            for (int i = 0; i < propertys.Length; i++)
            {
                var attributes = propertys[i].GetCustomAttributes(typeof(InjectAttribute), true);
                if (attributes.Length == 0)//have no inject attribute
                    continue;
                if (attributes.Length > 1)
                {
                    Assert.Exception("multiple inject attribute");
                }
                var injectAttribute = attributes[0] as InjectAttribute;
                var toObj = GetObjectWithAsNameFromIBindInfos(propertys[i].PropertyType, injectAttribute.AsName);
                propertys[i].SetValue(obj, toObj, null);
            }
        }

        object GetObjectFromIBindInfos(Type type)
        {
            return _iBindInfos.Find(x => { return x.Type == type; }).ToObj;
        }

        object GetObjectWithAsNameFromIBindInfos(Type type, string asName)
        {
            return _iBindInfos.Find(x => { return x.Type == type && x.AsName == asName; }).ToObj;
        }
    }
}

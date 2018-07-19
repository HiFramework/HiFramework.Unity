/***************************************************************
 * Description: 
 *
 * Documents: 
 * Author: hiramtan@live.com
***************************************************************/

using System;
using System.Reflection;

namespace HiFramework
{
    public class InjectComponent : Component, IInject
    {
        private readonly BindInfoContainer bindInfoContainer = new BindInfoContainer();
        /// <summary>
        /// Bind a type to a instance
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IBinding Bind<T>()
        {
            Type type = typeof(T);
            return new Binding(type, OnBindToFinish);
        }

        /// <summary>
        /// 当绑定实例完成时
        /// </summary>
        /// <param name="bindInfo"></param>
        private void OnBindToFinish(BindInfo bindInfo)
        {
            bindInfoContainer.Add(bindInfo);
        }

        /// <summary>
        /// Inject a instance
        /// Only property and filed for current now
        /// </summary>
        /// <param name="args"></param>
        public void Inject(object args)
        {
            InjectField(args);
            InjectProperty(args);
        }

        /// <summary>
        /// Inject field
        /// </summary>
        /// <param name="args"></param>
        private void InjectField(object obj)
        {
            var type = obj.GetType();
            var fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            for (int i = 0; i < fields.Length; i++)
            {
                var attributes = fields[i].GetCustomAttributes(typeof(InjectAttribute), true);
                if (attributes.Length == 0)//have no inject attribute
                    continue;
                InjectAttribute injectAttribute = null;
                for (int j = 0; j < attributes.Length; j++)
                {
                    if (attributes[j] is InjectAttribute)
                    {
                        injectAttribute = attributes[j] as InjectAttribute;
                        break;
                    }
                }
                if (injectAttribute == null)
                {
                    break; //There have field with Attribute but not InjectAttribute
                }
                var bindInfo = bindInfoContainer.GetBindInfo(fields[i].FieldType, injectAttribute.AsName);
                AssertThat.IsNotNull(bindInfo, "Bind to object is null");
                fields[i].SetValue(obj, bindInfo.Obj);
            }
        }

        /// <summary>
        /// Inject property
        /// </summary>
        /// <param name="args"></param>
        private void InjectProperty(object obj)
        {
            var type = obj.GetType();
            var propertys = type.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            for (int i = 0; i < propertys.Length; i++)
            {
                var attributes = propertys[i].GetCustomAttributes(typeof(InjectAttribute), true);
                if (attributes.Length == 0)//have no inject attribute
                    continue;
                InjectAttribute injectAttribute = null;
                for (int j = 0; j < attributes.Length; j++)
                {
                    if (attributes[j] is InjectAttribute)
                    {
                        injectAttribute = attributes[j] as InjectAttribute;
                        break;
                    }
                }
                if (injectAttribute == null)
                {
                    break; //There have property with Attribute but not InjectAttribute
                }
                var bindInfo = bindInfoContainer.GetBindInfo(propertys[i].PropertyType, injectAttribute.AsName);
                AssertThat.IsNotNull(bindInfo, "Bind to object is null");
                propertys[i].SetValue(obj, bindInfo.Obj, null);
            }
        }
    }
}

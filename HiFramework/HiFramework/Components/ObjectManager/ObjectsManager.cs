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
 using HiFramework.Assert;

namespace HiFramework
{
    class ObjectsManager : ComponentBase, IObjectManager
    {
        private readonly Dictionary<string, object> _objs = new Dictionary<string, object>();
        public override void OnCreated()
        {
        }

        public override void Dispose()
        {
            _objs.Clear();
        }

        public void AddObject(string name, object obj)
        {
            AssertThat.IsFalse(_objs.ContainsKey(name), "Alread have this key");
            _objs[name] = obj;
        }

        public object GetObject(string name)
        {
            AssertThat.IsTrue(_objs.ContainsKey(name), "Do not have this key");
            return _objs[name];
        }
    }
}

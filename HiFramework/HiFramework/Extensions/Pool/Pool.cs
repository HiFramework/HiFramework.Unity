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
    public class Pool<T> : IPool<T> where T : class, IPoolObject
    {
        private List<IPoolObject> _objects = new List<IPoolObject>();

        public int Count
        {
            get { return _objects.Count; }
        }

        public T GetOneObjectFromPool()
        {
            IPoolObject obj = null;
            if (_objects.Count > 0)
            {
                obj = _objects[0];
                obj.OnObjectOutPool();
                _objects.RemoveAt(0);
            }
            else
            {
                obj = Activator.CreateInstance<T>();
                obj.OnObjectCreate();
            }
            return obj as T;
        }

        public void RecleimThisObjectToPool(T t)
        {
            AssertThat.IsFalse(_objects.Contains(t), "Already have this object");
            _objects.Add(t);
            t.OnObjectInPool();
        }

        public void DisposeAll()
        {
            for (int i = 0; i < _objects.Count; i++)
            {
                _objects[i].OnObjectDispose();
            }
            _objects.Clear();
        }
    }
}
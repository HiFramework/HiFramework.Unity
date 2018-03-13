/****************************************************************
 * Description: 
 * 
 * Author: hiramtan@live.com
 *////////////////////////////////////////////////////////////////////////



using System;
using System.Collections.Generic;

namespace HiFramework
{
    class Pool<T> : IPool<T>
    {
        private readonly IPoolHandler<T> _iPoolHandler;
        private readonly Queue<T> _objects = new Queue<T>();

        public Pool(IPoolHandler<T> iPoolHandler)
        {
            _iPoolHandler = iPoolHandler;
        }

        public T Create()
        {
            var t = _iPoolHandler.Create();
            _objects.Enqueue(t);
            return t;
        }
        public void Destory()
        {
            while (_objects.Count > 0)
            {
                var obj = _objects.Dequeue();
                _iPoolHandler.Destory(obj);
            }
        }
        public T Get()
        {
            T t = default(T);
            if (_objects.Count > 0)
            {
                t = _objects.Dequeue();
                _iPoolHandler.OutFromPool(t);
            }
            else
            {
                t = Create();
            }
            return t;
        }
        public void Reclaim(T args)
        {
            _iPoolHandler.InToPool(args);
            _objects.Enqueue(args);
        }
    }
}

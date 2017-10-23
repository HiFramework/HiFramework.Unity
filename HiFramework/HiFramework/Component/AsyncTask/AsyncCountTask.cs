using System;

namespace HiFramework
{
    public class AsyncCountTask : AsyncTask
    {
        private readonly int _count;
        private int _i;

        public AsyncCountTask(Action<object> action, int count)
        {
            Action = action;
            _count = count;
        }

        protected override void OnTick()
        {
            _i++;
            if (_i > _count)
                IsDone = true;
        }

        protected override void Done()
        {
            Action(Obj);
        }
    }
}
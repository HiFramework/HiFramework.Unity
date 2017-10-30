using System.Collections.Generic;

namespace HiFramework
{
    internal class AsyncComponent : IComponent, ITick, IAsyncComponent
    {
        private readonly List<ITick> _iTicks = new List<ITick>();

        public void RegistTick(ITick iTick)
        {
            _iTicks.Add(iTick);
        }

        public void UnRegistTick(ITick iTick)
        {
            _iTicks.Remove(iTick);
        }

        public void OnRegist()
        {
            // async component is ready
        }

        public void UnRegistComponent()
        {
            _iTicks.Clear();
        }

        public void Tick()
        {
            for (var i = 0; i < _iTicks.Count; i++)
                _iTicks[i].Tick();
        }
    }
}
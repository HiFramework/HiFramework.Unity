/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiFramework_unity
 * Author: hiramtan@live.com
 ****************************************************************************/
namespace HiFramework
{
    public interface ISignalComponent
    {
        T GetSignal<T>() where T : class;
        void RemoveSignal<T>() where T : class;
    }
}


//public class AddGold : Signal<int>
//{

//}

//void Test()
//{
//    var signalComponent = Center.Get<ISignalComponent>();
//    var signal = signalComponent.GetSignal<AddGold>();
//    signal.AddListener((int gold) => { });

//    signal = signalComponent.GetSignal<AddGold>();
//    signal.Fire(100);
//}

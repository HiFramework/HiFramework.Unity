/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiFramework.Unity
 * Author: hiramtan@live.com
 ****************************************************************************/


namespace HiFramework.Unity
{
    public interface IAsyncTaskComponent
    {
        void AddTask(ITick task);
        void RemoveTask(ITick task);
    }
}
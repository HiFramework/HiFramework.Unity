/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiFramework_unity
 * Author: hiramtan@live.com
 ****************************************************************************/


namespace HiFramework
{
    public interface IAsyncTaskComponent
    {
        void AddTask(ITick task);
        void RemoveTask(ITick task);
    }
}
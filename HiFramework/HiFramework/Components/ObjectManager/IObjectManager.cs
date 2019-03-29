/****************************************************************************
 * Description: 非常简单的管理类,辅助其他逻辑共同使用
 * 
 * Document: https://github.com/hiramtan/HiFramework_unity
 * Author: hiramtan@live.com
 ****************************************************************************/

namespace HiFramework
{
    public interface IObjectManager
    {
        void AddObject(string name, object obj);
        object GetObject(string name);
    }
}

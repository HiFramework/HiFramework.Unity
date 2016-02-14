using HiFramework;
using UnityEngine;

public class Controller2 : Controller
{
    public override void OnMessage(Message paramMessage)
    {
        switch (paramMessage.id)
        {
            case "method1":
                Test(paramMessage);
                break;
        }

    }
    void Test(Message paramMessage)
    {
        Debug.Log("start game: " + paramMessage.body);

        
        Message msg = new Message("test2", null);
        paramMessage.EventHandler(msg);
    }
}

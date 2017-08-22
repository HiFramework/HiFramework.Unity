//****************************************************************************
// Description:
// Author: hiramtan@live.com
//***************************************************************************

using HiFramework;

public class GameWorld : Singleton_Unity<GameWorld>
{
    private static bool isExist;
    // Use this for initialization
    void Start()
    {
        if (!isExist)
        {
            DontDestroyOnLoad(gameObject);
            isExist = true;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Facade.GameTick.OnTick();
    }
}

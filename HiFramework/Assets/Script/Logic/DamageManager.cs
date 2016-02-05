using HiFramework;


public class DamageManager
{
    public static IModel ProcessDamage(IModel paramModel1, IModel paramModel2)
    {
        UnityEngine.Debug.Log("execute");
        return null;
    }

    public static void ProcessDamage(out IModel paramModel1, IModel paramModel2)
    {

        paramModel1 = null;
    }
}
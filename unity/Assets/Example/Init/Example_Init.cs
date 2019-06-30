/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiFramework_unity
 * Author: hiramtan@live.com
 ****************************************************************************/
using HiFramework;
using HiFramework.Core;
using HiFramework.Unity;
using UnityEngine;

public class Example_Init : MonoBehaviour
{
    private Animator animator;
    // Use this for initialization
    void Start()
    {
        Center.Init();
    }

    // Update is called once per frame
    void Update()
    {
        Center.Get<ITickComponent>().Tick(Time.deltaTime);
    }
}

using UnityEngine;
using System.Collections;

public class ActorView
{
    private Actor actor;
    protected GameObject gameObject;
    public ActorView(Actor paramActor, GameObject paramGo)
    {
        actor = paramActor;
        gameObject = paramGo;
    }
    public void Play(string paramName)
    {
        Animator animator = gameObject.GetComponent<Animator>();
        animator.CrossFade(paramName, CommonDefine.transitionDuration);
    }

    public void Destory()
    {
        MonoBehaviour.Destroy(gameObject);
    }




    Vector3[] test = new Vector3[] { Vector3.one, Vector3.left, Vector3.right, Vector3.zero };

    public void OnTick()
    {
        Debug.Log(Time.deltaTime);

        int x = Random.Range(0, 4);
        gameObject.transform.position = test[x];
    }
}
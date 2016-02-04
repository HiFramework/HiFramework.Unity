using UnityEngine;
using System.Collections;

public class GameStart : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        new GameObject("GameWorld").AddComponent<GameWorld>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

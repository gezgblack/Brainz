using UnityEngine;
using System.Collections;

public class destroyme : MonoBehaviour
{

    public float aliveTime; //how long we want an object to live

    // Use this for initialization
    void Awake()
    {

        Destroy(gameObject, aliveTime); //gameobject comes to life and gets destroyed within the specified time

    }

    // Update is called once per frame
    void Update()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFollowAI : MonoBehaviour {

    public Transform target;
    public float moveSpeed = 3f;
    public float rotationSpeed = 3f;
    public float range = 10f;
    public float range2 = 10f;
    public float stop = 0f;
    public Transform myTransform;

    public void Awake()
    {

        myTransform = transform;
    }

    public void Start()
    {

        target = GameObject.FindWithTag("Player").transform;
    }

    public void Update()
    {
        //rotate to look at the player
        var distance = Vector3.Distance(myTransform.position, target.position);
        if (distance <= range2 && distance >= range)
        {
            myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
            Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);
        }


        else if (distance <= range && distance > stop)
        {

            //move towards the player
            myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
            Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);
            myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
        }
        else if (distance <= stop)
        {
            myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
            Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);
        }


    }

}

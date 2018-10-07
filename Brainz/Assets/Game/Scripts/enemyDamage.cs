using UnityEngine;
using System.Collections;

public class enemyDamage : MonoBehaviour
{ //will be used on enemies

    public float damage; //how much damage this enemy will do
    public float damageRate; //how often the damage is applied
    public float pushBackForce; //the amount the charecter is moved upon damage

    float nextDamage; //the time at which the next damage can take place

    bool playerInRange = false; //will tell us if the player is within the collider

    GameObject thePlayer; //reference to my player
    public playerHealth thePlayerHealth; //players health

    // Use this for initialization
    void Start()
    {

        nextDamage = Time.time; //immediate damage, meaning there no delay in the damage
        thePlayer = GameObject.FindGameObjectWithTag("Player"); //find the object with the tag
        thePlayerHealth = GameObject.Find("FPSController").GetComponent<playerHealth>();

    }

    // Update is called once per frame
    void Update()
    {

        if (playerInRange)
        {
            Attack();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInRange = false;
        }
    }

    void Attack()
    {

        if (nextDamage <= Time.time)
        {
            thePlayerHealth.addDamage(damage); //add the damage in the player health script
            nextDamage = Time.time + damageRate; //only damaging when we are suppose to, at the damage rate basically

            pushBack(thePlayer.transform); //actually move the player, when damaged 
        }
    }

    void pushBack(Transform pushedObject)
    {//first gonna determine which direction to push

        Vector3 pushDirection = new Vector3(0, (pushedObject.position.y - transform.position.y), 0).normalized; //finding the difference between the actual object position and transform postion, normalized to get a unit vector
        pushDirection *= pushBackForce; //multiplaying our vector with the amount of force we want on the actual push

        //Rigidbody pushedRB = pushedObject.GetComponent<Rigidbody>(); //accessing our rigid body
        //pushedRB.velocity = Vector3.zero; //zeroing all the velocity on our player
        //pushedRB.AddForce(pushDirection, ForceMode.Impulse); //add the new velocity in our direction, explosive foce, being applied at the same time
    }
}
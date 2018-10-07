using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour {

public float enemyMaxHealth; //max health the enemy can have
    public float damageModifier; //multiplier, change how much damage this charecter takes
    public GameObject damageParticles;
    public GameObject drop; //enemy drops (ammo, health, etc)
    public bool drops; //if enemy drops pickup or not
    public AudioClip deathSound; //killed sound
    public bool canBurn; //if the enemy can take fire damage or not
    public float burnDamage; //fire damage
    public GameObject burnEffects; //fire particle system
    public float burnTime; //how long the fire burns for

    bool onFire; //if player on fire or not
    float nextBurn; //next burn damage
    float burnInterval = 1f; //time intervel
    float endBurn; //turn fire off

    public float currentHealth; //current health
    //public Slider enemyHealthIndicator; //enemy health slider
    AudioSource enemyAS;

	// Use this for initialization
	void Start () {

        currentHealth = enemyMaxHealth; //set health to max at start
        //enemyHealthIndicator.maxValue = enemyMaxHealth; //slider update
        //enemyHealthIndicator.value = currentHealth; //current health value
        enemyAS = GetComponent<AudioSource>(); //get sound
	}
	
	// Update is called once per frame
	void Update () {
	
        if(onFire && Time.time > nextBurn) //when is the next fire damage
        {
            addDamage(burnDamage);
            nextBurn += burnInterval;
        }
        if(onFire && Time.time > endBurn) //time to burn fire out
        {
            onFire = false;
            burnEffects.SetActive(false);
        }
	}

    public void addDamage(float damage) //damage dealer
    {
        //enemyHealthIndicator.gameObject.SetActive(true); //make indicator visible
        damage = damage * damageModifier; //amount of damage
        if (damage <= 0) return;
        currentHealth -= damage; //take damage amount from current health
        //enemyHealthIndicator.value = currentHealth; //update the health slider value
        //enemyAS.Play(); //play sound

        if (currentHealth <= 0)
        {
            makeDead();
        }
    }

    public void addFire()
    {
        if (!canBurn) return; //if enemy cant burn do nothing
        onFire = true; //if it can burn
        burnEffects.SetActive(true); //make fire visible
        endBurn = Time.time + burnTime; //how long we want the burn to occur for
        nextBurn = Time.time + burnInterval; //the next burn damage
    }

    void makeDead()
    {
       // AudioSource.PlayClipAtPoint(deathSound, transform.position, 0.15f); //make death sound
        Destroy(gameObject.transform.root.gameObject); //destroy object of the entire hierarchy
        if (drops) //if the enemy has a drop
            Instantiate(drop, transform.position, Quaternion.identity); //drop at position and rotation of enemy
    }

    public void damageFX(Vector3 point, Vector3 rotation) //to apply our effects
    {
        //Instantiate(damageParticles, point, Quaternion.Euler(rotation));
    }
}

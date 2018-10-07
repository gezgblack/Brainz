using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playerHealth : MonoBehaviour
{

    public float fullHealth; //Max health of my character
    public float currentHealth; //current health of the character

    //public GameObject playerDeathFX; //link to the particle effect

    //HUD Information
    public Slider playerHealthSlider; //our health slider in the player GUI
    //public Image damageScreen; //our damage image, bloody image screen
    Color flashColor = new Color(255f, 255f, 255f, 1f); //flash on the entire screen
    float flashSpeed = 5f; //the smoothing of the screen;
    bool damaged = false; //to create the flash

    //public Text endGameText;
    //scoreManager scoreManager;

    //Audio
    //Sound
    //AudioSource playerSounds; //audioSource to play the sounds
    //public AudioClip playerHealthPickup; //health pick up sound
    //public AudioClip playerHurt; //player hurt sound

    // Use this for initialization
    void Start()
    {

        currentHealth = fullHealth; //we want to start with max health
        playerHealthSlider.maxValue = fullHealth; //set slider to the max health value
        playerHealthSlider.value = currentHealth; //current health on slider
        //playerSounds = GetComponent<AudioSource>(); //source to audio player
        //scoreManager = FindObjectOfType<scoreManager>();
    }

    // Update is called once per frame
    void Update()
    {

        //hurt update
        if (damaged)
        {
            //damageScreen.color = flashColor; //flash on the screen
        }
        else //when no longer damaged
        {
            //damageScreen.color = Color.Lerp(damageScreen.color, Color.clear, flashSpeed * Time.deltaTime); //neutral screen
        }
        damaged = false; //no longer damaged
    }

    public void addDamage(float damage) //damage function, and the amount of damage it will do
    {
        currentHealth -= damage; //take the damage health amount away from health
        playerHealthSlider.value = currentHealth; //health slider to indicate damage has been taken, after the damage reduction
        damaged = true; //for damage screen to appear
        //playSound(playerHurt); //play player hurt sound
        if (currentHealth <= 0)
        {
            makeDead();
        }
    }

    public void addHealth(float health) //to add health
    {
        currentHealth += health; //add health amount picked up
        if (currentHealth > fullHealth) //if more health then max, set to max
        {
            currentHealth = fullHealth; //set to max health
        }
        playerHealthSlider.value = currentHealth; //set slider new value of the new health
        //playSound(playerHealthPickup); //play health pickup sound
    }

    public void makeDead() //to kill player
    {
        //Instantiate(playerDeathFX, transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
        //damageScreen.color = flashColor; //when dead, show damage taken flash screen effect
        playerHealthSlider.value = 0;
        Destroy(gameObject);
        //scoreManager.scoreIncreasing = false; //stop score from increasing any further
        //Animator endGameAnim = endGameText.GetComponent<Animator>(); //get animator for the dead text
        //endGameAnim.SetTrigger("endGame"); // Set trigger
    }

    void playSound(AudioClip playthesound) //play sound method
    {
        //playerSounds.clip = playthesound; //associate sound
        //playerSounds.Play(); //play the sound of shooting
    }
}
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class fireBullet : MonoBehaviour
{ //defines how the weapon works

    public float timeBetweenBullets = 0.15f; //every 15 hundred of a second we can fire the gun, how often we can shoot(to avoid having a large stream of bullets being shot)

    public GameObject projectile; //what we can shoot, the bullet
    float nextBullet; //when the next bullet can be shot

    //Bullet data
    public Slider playerAmmoSlider;
    public int maxRounds; //the max amount of bullets the weapon can have
    public int startingRounds; //the amount of bullets we start  
    public int remainingRounds; //rounds left

    //Sound
    AudioSource gunMuzzleAS;
    public AudioClip shootSound;
    public AudioClip reloadSound;

    //inventory info
    public Sprite weaponSprite; //the actual weapon image, that represents the weapon we are holding
    public Image weaponImage; //the location in the gui where the sprite is

    public FirstPersonController myPlayer;

    [SerializeField]
    private GameObject muzzle;

    // Use this for initialization
    void Awake()
    {

        nextBullet = 0; //no wait time, between each bullet
        remainingRounds = startingRounds; //the amount of rounds we start with
        playerAmmoSlider.maxValue = maxRounds; //set slider to the max
        playerAmmoSlider.value = remainingRounds; //the actual rounds in the slider value
        gunMuzzleAS = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

        //figure out which way the charecter is facing
        myPlayer = transform.root.GetComponent<FirstPersonController>(); //accesing player controls to see where we are facing

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (nextBullet < Time.time && remainingRounds > 0) //if the person is actually shooting, and remaining rounds are greater then 0
            {
                nextBullet = Time.time + timeBetweenBullets;

                Instantiate(projectile, muzzle.transform.position, Quaternion.Euler(myPlayer.transform.rotation.eulerAngles));

                playSound(shootSound); //play shoot sound

                remainingRounds -= 1; //with each bullet we shoot, delete 1 bullet

                playerAmmoSlider.value = remainingRounds; //update the amount of rounds we have after deletion
            }
        }
    }

    public void reload()
    {
        remainingRounds += 25; //set remaining ammo to the max amount
        if (remainingRounds >= maxRounds)
        {
            remainingRounds = maxRounds;
        }
        playerAmmoSlider.value = remainingRounds; //update the slider
        playSound(reloadSound); //play reload sound
    }

    void playSound(AudioClip playthesound) //play sound method
    {
        //gunMuzzleAS.clip = playthesound; //associate sound
        //gunMuzzleAS.Play(); //play the sound of shooting
    }

    public void initialializeWeapon()
    {
        gunMuzzleAS.clip = reloadSound;
        gunMuzzleAS.Play(); //weapon switch, reload sound play
        nextBullet = 0; //fire the weapon imediately
        playerAmmoSlider.maxValue = maxRounds; //set slider to max
        playerAmmoSlider.value = remainingRounds; //reflext the actual slider value (ammo value)
        weaponImage.sprite = weaponSprite; //change the sprite of th weapon
    }
}

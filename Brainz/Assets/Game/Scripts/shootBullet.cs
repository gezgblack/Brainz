using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class shootBullet : MonoBehaviour
{

    #region vars

    public float range = 10f; //how far the bullet can shoot
    public float damage = 5f; //how much damage it does

    Ray shootRay;
    RaycastHit shootHit; //register hits
    int shootableMask; //determine what can be shot
    LineRenderer gunLine; //to change to bullet
    [SerializeField]
    public moneyIncreaser money;

    //public int playerMoney = 0;
    //Text playerMoneyText;

    #endregion

    // Use this for initialization
    void Awake()
    {
        //playerMoneyText = GameObject.Find("moneyAmount").GetComponent<Text>();
        //playerMoneyText.text = playerMoney.ToString();
        money = GameObject.Find("moneyPanel").GetComponent<moneyIncreaser>();
        shootableMask = LayerMask.GetMask("Shootable"); //Shootable layers, in layers. Find the shootable layer.
        gunLine = GetComponent<LineRenderer>(); //line renderer reference

        shootRay.origin = transform.position; //Ray is being shot from where instantiated 
        shootRay.direction = transform.forward; //Shoot forward from position
        gunLine.SetPosition(0, transform.position); //where to start and finish drawing

        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask)) //chose the ray, out value will bring information as to what we hit, range is how far it will shoot, layermask to determine what can be hit/shot (shootable)
        {
            if (shootHit.collider.tag == "zombie") //if we have shot an enemy
            {
                //playerMoney++;
                money.increaseMoney();
                SetMoneyText();
                enemyHealth theEnemyHealth = shootHit.collider.GetComponent<enemyHealth>(); //get enemy health
                if (theEnemyHealth != null) //if we find it, and its not null
                {
                    theEnemyHealth.addDamage(damage); //make damage
                    theEnemyHealth.damageFX(shootHit.point, -shootRay.direction);
                }
            }
            //Hit an enemy will be entered here
            gunLine.SetPosition(1, shootHit.point); //endpoint of gunline, what did i hit, where did i hit it
        }
        else
        {
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range); //if nothing is hit, shoot a ray within the range we set
        }
    }


    void SetMoneyText()
    {
        //playerMoneyText.text = playerMoney.ToString();
    }

    void Update()
    {
        SetMoneyText();
    }
}

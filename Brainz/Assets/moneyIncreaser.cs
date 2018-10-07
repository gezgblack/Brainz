using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moneyIncreaser : MonoBehaviour {

    public int money;
    [SerializeField]
    public Text myMoneyText;
	
	// Update is called once per frame
	public void increaseMoney() {

        money++;
        myMoneyText.text = money.ToString();
    }
}

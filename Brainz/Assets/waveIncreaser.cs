using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class waveIncreaser : MonoBehaviour {

    public int waveAmount = 0;
    [SerializeField]
    public Text waveText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void increasewave () {

        waveAmount++;
        waveText.text = waveAmount.ToString();
	}
}

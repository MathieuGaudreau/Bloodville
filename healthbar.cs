using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Donne une vie au personnage

public class healthbar : MonoBehaviour {
    Image compImage; //coeurs
    public static float vies;
	// Use this for initialization

   //prend image des coeurs
	void Start () {
        compImage = GetComponent<Image>();
        compImage.fillAmount = 1;
        vies = 1;
	}
	
	// Update is called once per frame
	void Update () {
        compImage.fillAmount = vies;
	}
}

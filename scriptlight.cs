using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptlight : MonoBehaviour {
    public float ecart; //hauteur des lumiere
    public GameObject Perso;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = new Vector3(Perso.transform.position.x, Perso.transform.position.y + ecart, -10);
        if (transform.position.y <= 0.747f)
        {

            transform.position = new Vector3(transform.position.x, 0.747f, -4);
        }

        if (transform.position.x >= 45.04997f)
        {

            GetComponent<Light>().enabled = false;
        }
    }
}

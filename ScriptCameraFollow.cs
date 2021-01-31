using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//attacher a la camera qui suit le personnages
public class ScriptCameraFollow : MonoBehaviour
{
    public GameObject Perso; //personnage

    public float position;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //vector position camera = vector position perso

        transform.position = new Vector3(Perso.transform.position.x, Perso.transform.position.y + position, -8);


        if (transform.position.x <= -13.35f)
        {
            transform.position = new Vector3(-13.35f, transform.position.y,-8);
        }

        if (transform.position.x >= 107.0767f)
        {
            transform.position = new Vector3(107.0767f, transform.position.y,-8);
        }

  


	}
}

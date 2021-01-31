using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptDemon2 : MonoBehaviour {

    //fait attaquer le démon
    public GameObject perso;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //démon attaque si perso approche
		if(perso.gameObject.transform.position.x >= 81.32f)
        {
            GetComponent<Animator>().SetTrigger("isAttacking");
        }
	}
}

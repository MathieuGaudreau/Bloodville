using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//fait attaquer le demon
public class scriptDemon : MonoBehaviour {
    public GameObject perso;
	// Use this for initialization
	void Start () {
		
	}
	

    // Update is called once per frame
    // démon attaque quand person approche
	void Update () {
		if(perso.gameObject.transform.position.x >= 28)
        {
            GetComponent<Animator>().SetTrigger("isAttacking");
        }
	}
}

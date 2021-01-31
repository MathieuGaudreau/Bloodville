using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//fait attauquer le boss 1
public class Gnu : MonoBehaviour {
    public GameObject perso;

    public bool isDead;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //attauqe quand perso approche
        if (perso.gameObject.transform.position.x >= 104 && perso.gameObject.transform.position.x <= 107.5f)
        {
            GetComponent<Animator>().SetTrigger("isAttacking");
        }
    }

}

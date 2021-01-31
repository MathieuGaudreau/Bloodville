using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//fait attaquer quand perso approche
public class Shadow : MonoBehaviour {
    public GameObject perso;

    public bool isDead;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //attaque quand perso approche
        if (perso.gameObject.transform.position.x >= 128.5f)
        {
            GetComponent<Animator>().SetBool("isAttacking", true);
        }

        else
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }

    //meurt quand perso attauqe
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (perso)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }
}

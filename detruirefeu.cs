using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//détruit les boules de feu
public class detruirefeu : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y <= -6.25f)
        {
            Destroy(gameObject);
        }
    }

    //ce détruit quand touche au perso
    private void OnCollisionEnter2D(Collision2D autreobject)
    {
        if(autreobject.gameObject.name =="Perso")
        {
            Destroy(gameObject);
        }
    }
}

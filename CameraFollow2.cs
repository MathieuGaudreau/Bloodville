using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script attaché à la caméra
public class CameraFollow2 : MonoBehaviour
{
    public GameObject Perso;
    public float ecart;//pour régler hauteur camera


    // Update is called once per frame
	void Update ()
    {
        //vecteur position camera=vecteur position perso
        transform.position = new Vector3(Perso.transform.position.x, Perso.transform.position.y+ecart, -10);

        //LIMITES

        //si perso sort de la scene à droite (trouver valeur X sur la scène, ici 16)
        if (transform.position.x <= -2.01f)
        {
 
            transform.position = new Vector3(-2.01f, transform.position.y, -10);
        }

        if (transform.position.y >= 0.3503401f)
        {
    
            transform.position = new Vector3(transform.position.x, 0.3503401f,  - 10);
        }



    }
}

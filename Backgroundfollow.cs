using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script attaché au background
public class Backgroundfollow : MonoBehaviour
{
    public GameObject Perso; //personnage
    public float ecart;//pour régler hauteur background


    // Update is called once per frame
	void Update ()
    {
        
        if (transform.position.y <= 0.00120002f)
        {

            transform.position = new Vector3(transform.position.x, 0.00120002f, 0);
        }

        if (transform.position.y >= 0.00120002f)
        {

            transform.position = new Vector3(transform.position.x, 0.00120002f, 0);
        }

    }
}

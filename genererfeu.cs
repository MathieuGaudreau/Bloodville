using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//crée des boules de feu
public class genererfeu : MonoBehaviour
{
    public GameObject perso; //personnage
    public GameObject preFabFeu; //boule de feu
    public Transform sourceFlameball; //source de feu
    GameObject instanceFeu;
    Rigidbody2D rbInstanceFeu;

    //vitesses
    float vx = 0;
    float vy = -10;


    //position
    float xSourceFeu = 106;
    float ySourceFeu = -1.5f;


    //intervale
    float delai = 0.25f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //crée les boules de feu quand le perso arrive proche du boss
        delai = delai - Time.deltaTime;
        if (delai < 0 && perso.gameObject.transform.position.x >= 104 && perso.gameObject.transform.position.x <= 107.5f)
        {
            instanceFeu = Instantiate(preFabFeu, transform.position, transform.rotation);
            rbInstanceFeu = instanceFeu.GetComponent<Rigidbody2D>();
            rbInstanceFeu.velocity = new Vector2(vx, vy);
            xSourceFeu = Random.Range(103, 107);
            transform.position = new Vector2(xSourceFeu, ySourceFeu);
            delai = 0.25f;
        }

    }
}

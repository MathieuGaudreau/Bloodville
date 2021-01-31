using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenereTentacule : MonoBehaviour
{
    public GameObject perso; //personnage
    public GameObject prefabTentacule; //tentacules
    public Transform sourcetentacule;//position
    GameObject instancetentacule;
    Rigidbody2D rbInstanceTentacule;

    //vitesse
    float vx = 0;
    float vy = -10;

    //position
    float xSourceTenta = 128;
    float ySourceTenta = -11.611f;


    //intervale
    float delai = 0.25f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //fait apparaitre tentacule quand perso approche
        delai = delai - Time.deltaTime;
        if (delai < 0 && perso.gameObject.transform.position.x >= 129 && perso.gameObject.transform.position.x <= 131.084f)
        {

            instancetentacule = Instantiate(prefabTentacule, transform.position, transform.rotation);
            rbInstanceTentacule = instancetentacule.GetComponent<Rigidbody2D>();
            rbInstanceTentacule.velocity = new Vector2(vx, vy);
            xSourceTenta = Random.Range(128, 130.751f);
            transform.position = new Vector2(xSourceTenta, ySourceTenta);
            delai = 0.25f;
            Invoke("detruire", 2);
        }
    }

    //détruit tentacule 
    private void detruire()
    {
        Destroy(instancetentacule);
    }
}

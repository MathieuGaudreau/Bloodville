using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controle_Perso_2 : MonoBehaviour {
    //vitsse
    public float vitesseX;
    public float vitesseXMax;
    public float vitesseY;
    public float vitesseSaut;
    public float posX;
    public float posY;

    Rigidbody2D rbPerso;

    //objets intéractifs
    public GameObject coins;
    public GameObject gem;
    public GameObject coffre;
    public GameObject key;
    public GameObject pont;
    public GameObject elevator;
    public GameObject sourceTentacule;

    //son
    public AudioClip Coin;
    public AudioClip Gem;
    public AudioClip Potion;
    public AudioClip Frappe;

    public bool isHitting = false;

    public bool isDead = false;

    // Use this for initialization
    void Start()
    {
        rbPerso = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


        posX = rbPerso.position.x;
        posY = rbPerso.position.y;

        //comptre la vie
        if (healthbar.vies <= 0)
        {
            isDead = true;
        }
        //si il meurt
        if (isDead == true)
        {
            GetComponent<Animator>().SetTrigger("isDead");
            healthbar.vies = 0;
            Invoke("Restart", 2);
        }
        else
        {

            //course
            if (Input.GetKey("a"))
            {
                vitesseX = -vitesseXMax;
                GetComponent<SpriteRenderer>().flipX = true;
            }

            else if (Input.GetKey("d"))
            {
                vitesseX = vitesseXMax;
                GetComponent<SpriteRenderer>().flipX = false;
            }

            else
            {
                vitesseX = GetComponent<Rigidbody2D>().velocity.x;
            }

            //saut
            var surPLancher = Physics2D.OverlapCircle(transform.position, 0.1f);
            GetComponent<Animator>().SetBool("isJumping", !surPLancher);

            if (Input.GetKeyDown("w") && Physics2D.OverlapCircle(transform.position, 0.1f))
            {
                vitesseY = vitesseSaut;
                // GetComponent<Animator>().SetBool("isJumping", true);
            }

            else
            {
                vitesseY = GetComponent<Rigidbody2D>().velocity.y;
                //GetComponent<Animator>().SetBool("isJumping", false);

            }

            GetComponent<Rigidbody2D>().velocity = new Vector2(vitesseX, vitesseY);

            if (vitesseX > 0.1f || vitesseX < -0.1f)
            {
                GetComponent<Animator>().SetBool("isRunning", true);
            }

            else
            {
                GetComponent<Animator>().SetBool("isRunning", false);
            }


            //frappe
            if (Input.GetKey(KeyCode.Space) && isHitting == false)
            {
                
                isHitting = true;
                Invoke("StopAttack", 1);
                GetComponent<Animator>().SetTrigger("isHitting");
                GetComponent<Animator>().SetBool("isJumping", false);
                GetComponent<AudioSource>().PlayOneShot(Frappe, 0.5f);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D autreObjet)
    {

        //collision avec objets
        if (autreObjet.collider.tag == "Coins")
        {
            Texte.score += 50;
            GetComponent<AudioSource>().PlayOneShot(Coin, 0.5f);
            autreObjet.gameObject.SetActive(false);

        }

        if (autreObjet.collider.tag == "potion")
        {
            GetComponent<AudioSource>().PlayOneShot(Potion, 0.5f);
            healthbar.vies += 0.34f;
            autreObjet.gameObject.SetActive(false);
        }

        if (autreObjet.collider.tag == "Spikes")
        {
            isDead = true;
        }


        if (autreObjet.collider.tag == "gem")
        {
            Texte.score += 300;
            GetComponent<AudioSource>().PlayOneShot(Gem, 0.5f);
            autreObjet.gameObject.SetActive(false);

        }

        if(autreObjet.collider.name == "Coffre")
        {
            Invoke("fin", 0.5f);
        }

        if (autreObjet.collider.name == "Elevator")
        {
            elevator.GetComponent<Animator>().enabled = true;
            transform.parent = autreObjet.gameObject.transform;
        }

        if (autreObjet.collider.name == "Key")
        {
            pont.GetComponent<Animator>().enabled = true;
            autreObjet.gameObject.SetActive(false);
        }

        if (autreObjet.collider.name == "void")
        {
            Invoke("ChangeWorld", 0.01f);
        }


        //collision avec ennemies
        if (autreObjet.collider.tag == "ennemies")
        {
            if (isHitting == true)
            {
                Destroy(autreObjet.gameObject);
            }

            else
            {
                healthbar.vies -= 0.34f;
            }

        }

        if (autreObjet.collider.tag == "demon")
        {
            if (isHitting == true)
            {
                Destroy(autreObjet.gameObject);
                Invoke("voidkey", 0.5f);
            }

            else
            {
                healthbar.vies -= 0.34f;
            }

        }

        if(autreObjet.collider.tag == "tentacule")
        {
            if (isHitting == true)
            {
                Destroy(autreObjet.gameObject);
            }

            else
            {
                healthbar.vies -= 0.34f;
            }
        }

        if (autreObjet.collider.name == "Shadow")
        {
            if (isHitting == true)
            {

                autreObjet.gameObject.GetComponent<Animator>().SetBool("isDead",true);
                autreObjet.gameObject.GetComponent<Animator>().SetBool("isAttacking",false);

                autreObjet.gameObject.GetComponent<BoxCollider2D>().enabled = false;


                Destroy(autreObjet.gameObject, 2);

                Destroy(sourceTentacule, 1);

                coffre.SetActive(true);
            }

            else
            {
                healthbar.vies -= 0.34f;
            }
        }

        if (autreObjet.collider.tag == "fb")
        {
            healthbar.vies -= 0.34f;
        }
    }



    //arrete l'attaque
    public void StopAttack()
    {
        isHitting = false;
    }

    //change de scene vers monde 1
    public void ChangeWorld()
    {
        SceneManager.LoadScene("World1");
    }

    //permet de quitter l'assenceur
    private void OnCollisionExit2D(Collision2D autreObjet)
    {
        transform.parent = null;
    }

    //recommence le jeu
    public void Restart()
    {
        SceneManager.LoadScene("GameOver");
    }

    //apparait la clé
    public void voidkey()
    {
        key.SetActive(true);
    }

    //montre image de victoire
    public void fin()
    {
        SceneManager.LoadScene("Victory");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controle_Perso : MonoBehaviour {
    //vitesse
    public float vitesseX;
    public float vitesseXMax;
    public float vitesseY;
    public float vitesseSaut;
    //positions
    public float posX;
    public float posY;
    //son
    public AudioClip Coin;
    public AudioClip Gem;
    public AudioClip Potion;
    public AudioClip Frappe;

    Rigidbody2D rbPerso;
    //objets interactifs
    public GameObject coins;
    public GameObject gem;
    public GameObject key;
    public GameObject pont;
    public GameObject portail;
    public GameObject sourcefeu;

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

        //compte la vie
        if (healthbar.vies <= 0)
        {
            isDead = true;
        }

        //limites
        if (posX < -17.644f)
        {
            posX = -17.644f;
            rbPerso.position = new Vector2(posX, posY);
        }

        if (posX > 111.95f)
        {
            posX = 111.95f;
            rbPerso.position = new Vector2(posX, posY);
        }


        //mort du personnage
        if (isDead == true)
        {
            GetComponent<Animator>().SetTrigger("isDead");
            healthbar.vies = 0;
            Invoke("Restart", 2);
        }

        //si il n'est pas mort
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

            //saute
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


            //Attaque
            if (Input.GetKey(KeyCode.Space) && isHitting == false)
            {
                GetComponent<AudioSource>().PlayOneShot(Frappe, 0.5f);
                isHitting = true;
                Invoke("StopAttack", 1);
                GetComponent<Animator>().SetTrigger("isHitting");
                GetComponent<Animator>().SetBool("isJumping", false);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D autreObjet)
    {

        //contacte avec les objets
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


        if (autreObjet.collider.name == "Key")
        {
            pont.GetComponent<Animator>().enabled = true;
            autreObjet.gameObject.SetActive(false);
        }

        if (autreObjet.collider.name == "void")
        {
            Invoke("ChangeWorld", 0.01f);
        }

        if (autreObjet.collider.tag == "gem")
        {
            Texte.score += 300;
            GetComponent<AudioSource>().PlayOneShot(Gem, 0.5f);
            autreObjet.gameObject.SetActive(false);

        }


        //contacte avec les ennemies
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


        if (autreObjet.collider.name == "Gnu")
        {
            if (isHitting == true)
            {

                autreObjet.gameObject.GetComponent<Animator>().ResetTrigger("isAttacking");


                autreObjet.gameObject.GetComponent<BoxCollider2D>().enabled = false;

                Destroy(autreObjet.gameObject, 2);

                Destroy(sourcefeu, 1);

                portail.SetActive(true);
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

            if (autreObjet.collider.tag == "fb")
            {
                healthbar.vies -= 0.34f;
            }

        } 

    //arrete l'attaque
        private void StopAttack()
        {
            isHitting = false;
        }

    //change de scene dans le portail pour le monde 2
        public void ChangeWorld()
        {
            SceneManager.LoadScene("World2");
        }

    //change scene quand meurt
        public void Restart()
        {
            SceneManager.LoadScene("GameOver");
        }

        //fait apparaitre clé
        public void voidkey()
        {
            key.SetActive(true);
        }
    } 

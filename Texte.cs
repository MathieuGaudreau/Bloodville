using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//fait monter le score 
public class Texte : MonoBehaviour
{
    public static int score;
    Text txtcomposant;
    // Use this for initialization
    void Start()
    {

    }
    //initialise de score
    private void Awake()
    {
        txtcomposant = GetComponent<Text>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        txtcomposant.text = "points :   " + score;
    }
}

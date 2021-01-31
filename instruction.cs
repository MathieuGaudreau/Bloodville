using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//change de scene
public class instruction : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
	}
    //change la scene
    public void Play(int numeroScene)
    {
        SceneManager.LoadScene(numeroScene);
    }
}

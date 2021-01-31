using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//change scene
public class NextScene : MonoBehaviour {

    // Use this for initialization

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    //change scene
    public void Play(int numeroScene)
    {
        SceneManager.LoadScene(numeroScene);
    }
}

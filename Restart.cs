using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//fait recommencer le jeu
public class Restart : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

     
    }
    //change la scene
        public void Play(int numeroScene)
        {
            SceneManager.LoadScene(numeroScene);
        }
  
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Left : MonoBehaviour
{
    public int Restart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            GameData.playerScore += 1;
            //Debug.Log("Player score: " + GameData.playerScore);
            //Debug.Log("Computer score: " + GameData.computerScore);
            SceneManager.LoadScene(Restart);
        }
    }
}



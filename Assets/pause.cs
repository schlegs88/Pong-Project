using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class pause : MonoBehaviour
{
    private bool isPaused = false;
    public TextMeshProUGUI pauseInfo;
    public GameObject ball;
    
    // Start is called before the first frame update
    void Start()
    {
        if (pauseInfo == null || ball == null)
    {
        Debug.LogError("pauseInfo or ball not assigned!");
        return;
    }
        //make sure the ball is visible the text is not visible
        pauseInfo.enabled = false;
        ball.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Check for spacebar key press
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Toggle pause state
            isPaused = !isPaused;
            // Pause or resume the game based on the state
            if (isPaused)
            {
                Time.timeScale = 0f; // Set time scale to 0 to pause the game

            }else{
                Time.timeScale = 1f; // Set time scale back to 1 to resume the game
            }
            pauseInfo.enabled = !pauseInfo.enabled;
            ball.SetActive(!ball.activeSelf);

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("NOW QUITTING...");
            Application.Quit();
        }
    }
}
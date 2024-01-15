using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PScore: MonoBehaviour
{
    public TextMeshProUGUI playerSText;
    public TextMeshProUGUI computerSText;

    void Start(){
        UpdateScore();
    }

    void Update(){
        UpdateScore();
    }

    void UpdateScore(){
        playerSText.text = "player: " + GameData.playerScore;
        computerSText.text = "computer: " + GameData.computerScore;
    }
}

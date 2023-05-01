using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    //player/enemy score counter and text components
    public int playerScoreCount = 0;
    public Text playerScore;
    public int agentScoreCount = 0;
    public Text agentScore;

    //updating score
    private void Update()
    {
        playerScore.text = "Player: "+playerScoreCount;
        agentScore.text = "AI: " + agentScoreCount;
    }

    //start button to load main scene
    public void StartGame()
    {
        SceneManager.LoadScene("Pong");
    }

    //exit button to quit the game
    public void Exit()
    {
        Application.Quit();
    }
}

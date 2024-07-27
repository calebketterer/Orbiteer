using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public MenuScript menus;
    public ShipScript ship;

    public int PlayerScore;
    public int HighScore;
    public Text ScoreText;
    public Text HighScoreText;

    public bool GameIsRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        menus = GameObject.FindGameObjectWithTag("Menu").GetComponent<MenuScript>();
        ship = GameObject.FindGameObjectWithTag("Ship").GetComponent<ShipScript>();

        HighScore = PlayerPrefs.GetInt("High Score", HighScore);
        if (HighScore > 0)
        {
            HighScoreText.text = "High Score: " + HighScore.ToString();
            Debug.Log("High Score set to " + HighScore.ToString());
        }

    }

    public void GameOver() {
        if (PlayerScore > HighScore) {
            HighScore = PlayerScore;
            HighScoreText.text = "High Score: " + HighScore.ToString();
            Debug.Log("High Score set to " + HighScore.ToString() + ".");
            PlayerPrefs.SetInt("High Score", PlayerScore);
        }
        menus.GameOverMenu();
    }

    public void ResetScores() {
        HighScore = 0;
        HighScoreText.text = " ";
        Debug.Log("High score reset.");
        PlayerPrefs.SetInt("High Score", 0);
    }

    [ContextMenu("Increase Score")]
    public void addScore() {
        if (ship.ShipIsFlyable)
        {
            PlayerScore++;
            ScoreText.text = PlayerScore.ToString();
            Debug.Log("Score increased by 1.");
        }
    }
}

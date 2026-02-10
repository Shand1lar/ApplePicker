using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text finalScoreGT;
    public Text highScoreGT;
    public Text highScoreMessage;
    // Start is called before the first frame update
    void Start()
    {
        int score = Basket.latestScore;
        finalScoreGT.text = "Final Score: " + score.ToString();
        highScoreGT.text = "High Score: " + HighScore.score.ToString();
        
        if(score>=PlayerPrefs.GetInt("HighScore")) {
             highScoreMessage.text = "New High Score!";
        } else {
             highScoreMessage.text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart() {
        SceneManager.LoadScene ("_Scene_0");
    }

    public void ReturnToStartScreen() {
        SceneManager.LoadScene ("_Scene_Start");
    }
}

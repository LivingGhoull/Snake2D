using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreSystem : MonoBehaviour {

    [SerializeField] TextMeshProUGUI score;
    [SerializeField] TextMeshProUGUI highScore;

    // Start is called before the first frame update
    private void Awake() {
        if (PlayerPrefs.GetInt("highScore") == 0) {
            PlayerPrefs.SetInt("highScore", 0);
        }
    }

    public void Highscore(int points) {
        score.text = "Score: " + points;
        if (PlayerPrefs.GetInt("highScore") < points) {
            PlayerPrefs.SetInt("highScore", points);
        }
        highScore.text = "HighScore: " + PlayerPrefs.GetInt("highScore");
    }
}

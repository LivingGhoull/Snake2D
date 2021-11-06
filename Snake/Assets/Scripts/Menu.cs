using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartNow() {
        SceneManager.LoadScene("SnakeGame");
    }
    public void ResetGame() {
        PlayerPrefs.DeleteAll();
    }
    public void ExitGame() { 

        Application.Quit();
    }

}

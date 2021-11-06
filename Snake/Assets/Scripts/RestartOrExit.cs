using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartOrExit : MonoBehaviour
{
    public void ReloadGame() {
        SceneManager.LoadScene("SnakeGame");
    }

    public void GoBack() {
        SceneManager.LoadScene("Menu");
    }
}

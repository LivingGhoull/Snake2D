using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    public void StartNow() {
        audioSource.Play();
        SceneManager.LoadScene("SnakeGame");
    }
    public void ResetGame() {
        audioSource.Play();
        PlayerPrefs.DeleteAll();
    }
    public void ExitGame() {
        audioSource.Play();
        Application.Quit();
    }
}

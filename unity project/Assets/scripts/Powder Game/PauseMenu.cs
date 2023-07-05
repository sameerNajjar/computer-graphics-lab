using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool paused = false;
    public GameObject pauseMenu;
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            paused = !paused;
            if (paused) {
                Pause();
            }
            else {
                Resume();
            }
        }
    }
    public void Resume() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;

    }
    private void Pause() {
        pauseMenu.SetActive(true);
        Time.timeScale =0f;
    }
    public void LoadMainMenu() {
        SceneManager.LoadScene("StartMenu");
    }
}

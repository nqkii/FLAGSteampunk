using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private ApplyBrightness applyBrightness;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu screen");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }

    public void Options()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void CloseOptions()
    {
        pauseMenu.SetActive(true);
        optionsMenu.SetActive(false);
        applyBrightness.changeBrightness();
    }
}

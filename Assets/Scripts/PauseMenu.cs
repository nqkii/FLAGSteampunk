using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject tutorialScreen;
    [SerializeField] private GameObject creditsScreen;
    [SerializeField] private ApplyBrightness applyBrightness;

    public Animator transition;

    public void Start()
    {
        transition.SetBool("Start1", false);
    }

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
        StartCoroutine(loadLevel("Menu screen"));
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

    public void HelpScreen()
    {
        optionsMenu.SetActive(false);
        tutorialScreen.SetActive(true);
    }

    public void CloseHelpScreen()
    {
        optionsMenu.SetActive(true);
        tutorialScreen.SetActive(false);
    }

    public void CreditsScreen()
    {
        optionsMenu.SetActive(false);
        creditsScreen.SetActive(true);
    }

    public void CloseCreditsScreen()
    {
        optionsMenu.SetActive(true);
        creditsScreen.SetActive(false);
    }

    IEnumerator loadLevel(string scene)
    {
        transition.SetBool("Start1", true);

        yield return new WaitForSeconds(1);

        SceneManager.LoadSceneAsync(scene);
    }
}

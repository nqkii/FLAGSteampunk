using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // This is for a default Play button (optional)
    public string playSceneName;

    public Animator transition;

    public void Start()
    {
        transition.SetBool("Start1", false);
    }

    // Play button (uses the default scene above)
    public void PlayGame()
    {
        StartCoroutine(loadLevel(playSceneName));
    }

    // Generic scene loader (use this for Options, Credits, etc.)
    public void LoadScene(string sceneName)
    {
        StartCoroutine(loadLevel(sceneName));
    }

    // Quit game
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Closed"); // This shows in editor since Quit doesn't work there
    }

    IEnumerator loadLevel(string scene)
    {
        transition.SetBool("Start1", true);

        yield return new WaitForSecondsRealtime(1);

        SceneManager.LoadSceneAsync(scene);
    }
}
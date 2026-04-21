using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // This is for a default Play button (optional)
    public string playSceneName;

    // Play button (uses the default scene above)
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(playSceneName);
    }

    // Generic scene loader (use this for Options, Credits, etc.)
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    // Quit game
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Closed"); // This shows in editor since Quit doesn't work there
    }
}
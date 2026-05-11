using UnityEngine;
using UnityEngine.SceneManagement;


public class EndOfRunScreen : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene("Slice");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu screen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}

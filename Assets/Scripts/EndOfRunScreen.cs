using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndOfRunScreen : MonoBehaviour
{
    public Animator transition;

    public void Start()
    {
        transition.SetBool("Start1", false);
    }

    public void PlayAgain()
    {
        StartCoroutine(loadLevel("Slice"));
    }

    public void MainMenu()
    {
        StartCoroutine(loadLevel("Menu screen"));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator loadLevel(string scene)
    {
        transition.SetBool("Start1", true);

        yield return new WaitForSecondsRealtime(1);

        SceneManager.LoadSceneAsync(scene);
    }

}

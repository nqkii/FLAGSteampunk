using TMPro;
using UnityEngine;

public class TempScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highscoreText;
    [SerializeField] GameObject newHighscore;

    void Start()
    {
        if (PlayerPrefs.GetInt("NewHighscore") == 1)
        {
            newHighscore.SetActive(true);
        }

        scoreText.text = (PlayerPrefs.GetInt("RecentScore")).ToString();
        highscoreText.text = (PlayerPrefs.GetInt("Highscore")).ToString();
    }

}

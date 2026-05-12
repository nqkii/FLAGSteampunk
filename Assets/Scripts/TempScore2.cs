using UnityEngine;

public class TempScore2 : MonoBehaviour
{

    public void updateRecentScore(float _score)
    {
        int score = Mathf.FloorToInt(_score);

        PlayerPrefs.SetInt("RecentScore", score);
        float highscore = PlayerPrefs.GetInt("Highscore");
        if (score >= highscore)
        {
            PlayerPrefs.SetInt("Highscore", score);
            PlayerPrefs.SetInt("NewHighscore", 1);
        }
        else
        {
            PlayerPrefs.SetInt("NewHighscore", 0);
        }
    }
}

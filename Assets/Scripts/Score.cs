using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI scoreText;
    public float score = 0.0f;
    int lastHighScore = 0;
    bool newHighScore;
    string highScoreFilePath;

    Vector3 startPos = new Vector3(2, 1.23f, 0.1f);

    void Start()
    {
        highScoreFilePath = Path.Combine(Application.persistentDataPath, "RunnerHighScore.txt");
    }

    public int LoadHighScore()
    {
        //save high score
        if(File.Exists(highScoreFilePath))
        {
            string savedHighScore = File.ReadAllText(highScoreFilePath);
            if(int.TryParse(savedHighScore, out int highScore))
            {
                lastHighScore = highScore;
                return highScore;
            }
        }
        return 0;
    }

    void Update()
    {
        //subtracts the starting position (2) from where the player is in that moment
        float dist = Mathf.Abs(player.transform.position.x - startPos.x);
        score = dist;

        if(score > 0.0f)
        {
            scoreText.text = Mathf.FloorToInt(score).ToString() + " m";
        }
    }

    public void SaveHighScore()
    {
        if (newHighScore)
        {
            File.WriteAllText(highScoreFilePath, Mathf.FloorToInt(score).ToString());
        }
    }

    public float getScore()
    {
        return score;
    }
}

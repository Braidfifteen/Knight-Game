using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public static int score;
    public static bool scoreUpdated = false;

    private void Start()
    {
        score = 0;
        setScore();
    }

    private void Update()
    {
        if (scoreUpdated)
        {
            setScore();
            scoreUpdated = false;
        }
    }

    public static void AddToScore(int points)
    {
        ScoreManager.score += points;
        ScoreManager.scoreUpdated = true;
    }

    private void setScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
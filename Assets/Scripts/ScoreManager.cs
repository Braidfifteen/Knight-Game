using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Animator anim;
    public static int score;
    public static bool scoreUpdated = false;
    private int prevScore;

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

    public static void AddToScore(int amount)
    {
        ScoreManager.score += amount;
        ScoreManager.scoreUpdated = true;
    }

    public static void DecreaseScore(int amount)
    {
        ScoreManager.score -= amount;
        ScoreManager.scoreUpdated = true;
    }

    private void setScore()
    {
        scoreText.text = score.ToString();
        if (score > prevScore)
        {
            anim.SetTrigger("ScoreUpTrig");
        }

        else if (score < prevScore)
        {
            anim.SetTrigger("ScoreDownTrig");
        }
        prevScore = score;
    }
}
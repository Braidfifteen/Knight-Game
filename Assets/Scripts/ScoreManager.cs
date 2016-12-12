using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public GameObject player;
    public GameObject parent;
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
        int randNum = Random.Range(1, 11);
        if (scoreUpdated && score > prevScore)
        {
            //This must be changed
            if (randNum == 5)
            {
                score += 5;
                setScore();
                scoreUpdated = false;
                GameObject multiplier = CanvasObjectPooler.SharedInstance.GetPooledObject("Multiplier");

                if (multiplier != null)
                {
                    if (player.transform.rotation.y == 1)
                    {

                        multiplier.transform.position = new Vector3(player.transform.position.x + 1.2f, player.transform.position.y + 1.5f, 0);
                    }

                    else if (player.transform.rotation.y == 0)
                        multiplier.transform.position = new Vector3(player.transform.position.x + .2f, player.transform.position.y + 1.5f, 0);

                    multiplier.transform.rotation = transform.rotation;

                    multiplier.transform.parent = transform;
                    multiplier.SetActive(true);
                }
                GameObject multiplierSound = ObjectPooler.SharedInstance.GetPooledObject("Multiplier");
                if (multiplierSound != null)
                {
                    multiplierSound.transform.position = transform.position;
                    multiplierSound.transform.rotation = transform.rotation;
                    multiplierSound.transform.parent = transform;
                    multiplierSound.SetActive(true);
                }
            }
            else
            {
                setScore();
                scoreUpdated = false;
                GameObject sound = ObjectPooler.SharedInstance.GetPooledObject("ItemCatchedSound");
                if (sound != null)
                {
                    sound.transform.position = transform.position;
                    sound.transform.rotation = transform.rotation;
                    sound.SetActive(true);
                }

            }
        }
        else if (scoreUpdated && score < prevScore)
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text highScoreText;

    [SerializeField] Leaderboard lb;
    [SerializeField] InputField playerName;
    [SerializeField] Button acceptName;

    public static int score;
    int count;
    float timeForBonus;

	void Start ()
    {
        score = PlayerPrefs.GetInt("score", 0);
        scoreText.text = "Score: " + score.ToString();
        highScoreText.text = "HighScore: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
	}
	
	void Update ()
    {
        ScoreUpdate();
	}

    public void ScoreUpdate()
    {
        scoreText.text = "Score: " + score.ToString();
        HighScore();
        PlayerPrefs.SetInt("score", score);
    }

    public void HighScore()
    {
        int newScore = score;

        if (newScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", newScore);
            highScoreText.text = "HighScore: " + newScore.ToString();
        }
    }

    public void SavePlayerName()
    {
        lb.VerifyScores(score, playerName.text);
        playerName.gameObject.SetActive(false);
        acceptName.gameObject.SetActive(false);
    }

    public static void AddScore(int newValue)
    {
        score += newValue;
    }

    public static void ResetScore()
    {
        PlayerPrefs.DeleteKey("score");
    }


    void Bonus()
    {
        for (float i = 0; i < 2; i += Time.deltaTime)
        {
            if (count > 5) count = 5;

            switch (count)
            {
                case 2:
                    score += 10 * 2;
                    break;
                case 3:
                    score += 10 * 3;
                    break;
                case 4:
                    score += 10 * 4;
                    break;
                case 5:
                    score += 10 * 5;
                    break;
                default:
                    break;
            }
        }
        //timeForBonus += Time.deltaTime;
        count = 0;


        //if (timeForBonus < 2)
        //{
            
        //}
        //else if (timeForBonus >= 2)
        //{
        //    timeForBonus = 0;
        //}
        


        //yield return new WaitForSeconds(2f);
        // count = 0;
        //StopCoroutine(Bonus());
    }
}

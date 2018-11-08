using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public static int score;
    int count;
    float timeForBonus;
    public static bool isDetroying;

	void Start ()
    {
        scoreText.text = "Score: 0";
	}
	
	void Update ()
    {
        ScoreUpdate();
        scoreText.text = "Score: " + score.ToString();
        Debug.Log(timeForBonus);
	}

    public void ScoreUpdate()
    {
        if(isDetroying)
        {
            score += 10;
            count++;
            Bonus();
            //isDetroying = false;
        }
        //return score;
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
        isDetroying = false;
        Debug.Log(count);
    }
}

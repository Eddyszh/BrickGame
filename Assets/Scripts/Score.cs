using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    static int score;
    public static bool isDetroying;
	// Use this for initialization
	void Start ()
    {
        scoreText.text = "Score: 0";
	}
	
	// Update is called once per frame
	void Update ()
    {
        scoreText.text = "Score: " + ScoreUpdate().ToString();
	}

    public static int ScoreUpdate()
    {
        if(isDetroying)
        {
            isDetroying = false;
            return score += 10;
        }
        return score;
    }
}

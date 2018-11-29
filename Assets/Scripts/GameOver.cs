using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void StopGame()
    {
        GameStatesSwitch.ChangeToGameOverState();
        StartCoroutine(Stop());
    }

    public void ResetGame()
    {
        StartCoroutine(Reset());
    }

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(.8f);
        Time.timeScale = 0f;
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(.8f);
        Loader.ResetLevel();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    [SerializeField] AudioManager am;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (BossInfo.isBossDead)
        {
            am.ChangeMusic(4);
        }
	}

    public void StopGame()
    {
        am.ChangeMusic(5);
        GameStatesSwitch.ChangeToGameOverState();
        StartCoroutine(Stop());
    }

    public void ResetGame()
    {
        StartCoroutine(Reset());
    }

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(3f);
        Time.timeScale = 0f;
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(.8f);
        Loader.ResetLevel();
    }
}

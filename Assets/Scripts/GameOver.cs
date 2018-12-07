using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] AudioManager am;

    [SerializeField] GameObject victoryImage;
    [SerializeField] GameObject defeatImage;
    [SerializeField] GameObject leaderboardImage;

	void Start ()
    {
        victoryImage.SetActive(false);
        defeatImage.SetActive(false);
        leaderboardImage.SetActive(false);
	}
	
	void Update ()
    {
        Victory();
	}

    public void Defeat()
    {
        defeatImage.SetActive(true);
        leaderboardImage.SetActive(true);
        //am.EventMusic(1);
        GameStatesSwitch.ChangeToGameOverState();
        StartCoroutine(Stop());
    }

    public void Victory()
    {
        if (BossInfo.isBossDead)
        {
            victoryImage.SetActive(true);
            leaderboardImage.SetActive(true);
            GameStatesSwitch.ChangeToGameOverState();
            //am.EventMusic(0);
        }
    }

    public void ResetGame()
    {
        Score.ResetScore();
        Loader.ResetLevel();
    }

    public void ResetLevel1()
    {
        for (int x = 0; x < 10; x++)
        {
            for (int y = 1; y < 16; y++)
            {
                if (Grid2D.grid[x, y] == null) continue;
                Destroy(Grid2D.grid[x, y].gameObject);
                Grid2D.grid[x, y] = null;
            }
        }
    }

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(.8f);
        Time.timeScale = 0f;
    }
}

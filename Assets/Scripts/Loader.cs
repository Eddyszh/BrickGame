using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    bool level1 = false;
    bool level2 = false;
    bool level3 = false;

    public void InitGame()
    {
        level1 = true;
        SceneManager.LoadScene(1);
    }

    void Update()
    {
        ChangeLevel();
    }

    void ChangeLevel()
    {
        if (level1 == true && Score.score == 350)
        {
            level1 = false;
            level2 = true;
            SceneManager.LoadScene(2);
        }
        if(level2 == true && Score.score == 1200)
        {
            level2 = false;
            level3 = true;
            SceneManager.LoadScene(3);
        }

    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    public static bool level1 = false;
    public static bool level2 = false;
    public static bool level3 = false;

    [SerializeField] AudioManager am;

    private void Awake()
    {
        GameStatesSwitch.ChangeToMainMenuState();
        am.ChangeMusic(0);
    }

    public void InitGame()
    {
        GameStatesSwitch.ChangeToPlayState();
        level1 = true;
        SceneManager.LoadScene(1);
        am.ChangeMusic(1);
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
            am.ChangeMusic(2);
        }
        if(level2 == true && Score.score == 1200)
        {
            level2 = false;
            level3 = true;
            SceneManager.LoadScene(3);
            am.ChangeMusic(3);
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        GameStatesSwitch.ChangeToMainMenuState();
    }

    public static void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        Application.Quit();
    }
}

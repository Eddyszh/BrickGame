using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum ActualScene
{
    MainMenu,
    Level1,
    Level2,
    Level3
}

public class Loader : MonoBehaviour
{
    public ActualScene a_scene;
    public static bool main = false;
    public static bool level1 = false;
    public static bool level2 = false;
    public static bool level3 = false;

    [SerializeField] AudioManager am;

    private void Start()
    {
        //DontDestroyOnLoad(gameObject);
        //sceneName = SceneManager.GetActiveScene().name;
        LoadMusicScene(a_scene);
    }

    public void InitGame()
    {
        GameStatesSwitch.ChangeToPlayState();
        level1 = true;
        //am.ChangeLevelMusic(1);
        Score.ResetScore();
        SceneManager.LoadScene(1);
    }

    void Update()
    {
        ChangeScene();
    }

    public void LoadMusicScene(ActualScene actual)
    {
        switch (actual)
        {
            case ActualScene.MainMenu:
                am.ChangeLevelMusic(0);
                break;
            case ActualScene.Level1:
                am.ChangeLevelMusic(1);
                break;
            case ActualScene.Level2:
                am.ChangeLevelMusic(2);
                break;
            case ActualScene.Level3:
                am.ChangeLevelMusic(3);
                break;
            default:
                break;
        }

    }

    void ChangeScene()
    {
        if (level1 == true && Score.score == 350)
        {
            level1 = false;
            level2 = true;
            SceneManager.LoadScene(2);
            //am.ChangeLevelMusic(2);
        }

        if(level2 == true && Input.GetKeyDown(KeyCode.W) && ChargeEnergySlider.isFullPower == true)
        {
            level2 = false;
            level3 = true;
            SceneManager.LoadScene(3);
            //am.ChangeLevelMusic(3);
        }
    }

    public void MainMenu()
    {
        GameStatesSwitch.ChangeToMainMenuState();
        SceneManager.LoadScene(0);
        level1 = false;
        level2 = false;
        level3 = false;
        Time.timeScale = 1.0f;
    }

    public static void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        PlayerInfo.lives = 3;
    }

    public void Exit()
    {
        Application.Quit();
    }
}

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
    public static bool level1 = false;
    public static bool level2 = false;
    public static bool level3 = false;

    [SerializeField] AudioManager am;

    static Loader instance;

    public static Loader Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Loader>();

                if (instance == null)
                {
                    GameObject go = new GameObject(typeof(Loader).ToString());
                    go.AddComponent<Loader>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        //sceneName = SceneManager.GetActiveScene().name;
        LoadMusicScene(a_scene);
    }

    public void InitGame()
    {
        GameStatesSwitch.ChangeToPlayState();
        //level1 = true;
        SceneManager.LoadScene(1);
    }

    void Update()
    {
        ChangeScene();

        /*if (sceneName == )
        {
            GameStatesSwitch.ChangeToMainMenuState();
            am.ChangeMusic(0);
        }
        */
    }

    public void LoadMusicScene(ActualScene actual)
    {
        switch (actual)
        {
            case ActualScene.MainMenu:
                GameStatesSwitch.ChangeToMainMenuState();
                am.ChangeMusic(0);
                break;
            case ActualScene.Level1:
                level1 = true;
                am.ChangeMusic(1);
                break;
            case ActualScene.Level2:
                am.ChangeMusic(2);
                break;
            case ActualScene.Level3:
                am.ChangeMusic(3);
                break;
            default:
                break;
        }

    }

    void ChangeScene()
    {
        if (level1 == true && Score.score == 150)
        {
            level1 = false;
            level2 = true;
            SceneManager.LoadScene(2);
        }
        if(level2 == true && Score.score == 300)
        {
            level2 = false;
            level3 = true;
            SceneManager.LoadScene(3);
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        am.ChangeMusic(0);
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

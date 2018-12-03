using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum States
{
    MainMenu,
    Play,
    GameOver
}

public class GameManager : MonoBehaviour
{
    public delegate void ModifiedState(States newState);
    public event ModifiedState OnModifiedState;

    static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<GameManager>();

                if (instance == null)
                {
                    GameObject go = new GameObject(typeof(GameManager).ToString());
                    go.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }

    States gameState;

    public States GameState
    {
        get
        {
            return gameState;
        }

        set
        {
            if (gameState != value)
            {
                bool changeState = false;
                switch (gameState)
                {
                    case States.MainMenu:
                        if (value == States.Play) changeState = true;
                        break;
                    case States.Play:
                        if (value == States.GameOver) changeState = true;
                        break;
                    case States.GameOver:
                        if (value == States.MainMenu || value == States.Play) changeState = true;
                        break;
                }

                if (changeState)
                {
                    gameState = value;
                    if (OnModifiedState != null) OnModifiedState(gameState);
                }
            }
        }
    }


    // Use this for initialization
    void Awake ()
    {
        //DontDestroyOnLoad(gameObject);
	}
}

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
    static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

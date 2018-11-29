using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatesSwitch : MonoBehaviour
{
    public static void ChangeToMainMenuState()
    {
        GameManager.Instance.GameState = States.MainMenu;
    }

    public static void ChangeToPlayState()
    {
        GameManager.Instance.GameState = States.Play;
    }

    public static void ChangeToGameOverState()
    {
        GameManager.Instance.GameState = States.GameOver;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    [SerializeField] GameObject optionsImage;
    [SerializeField] GameObject mainImage;

	void Start ()
    {
        optionsImage.SetActive(false);
	}

    public void EnterOptions()
    {
        if (GameManager.Instance.GameState == States.MainMenu)
        {
            optionsImage.SetActive(true);
            mainImage.SetActive(false);
        }

        if (GameManager.Instance.GameState == States.Play) optionsImage.SetActive(true);
    }

    public void ExitOptions()
    {
        if (GameManager.Instance.GameState == States.MainMenu)
        {
            optionsImage.SetActive(false);
            mainImage.SetActive(true);
        }

        if(GameManager.Instance.GameState == States.Play) optionsImage.SetActive(false);
    }
}

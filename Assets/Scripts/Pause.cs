using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject pauseImage;
    [SerializeField] Options options;

    void Start()
    {
        pauseImage.SetActive(false);
    }

    void Update ()
    {
        if (Input.GetKey(KeyCode.Escape) && GameManager.Instance.GameState == States.Play) OnPause();
	}

    void OnPause()
    {
        if (Time.timeScale == 1.0f)
            Time.timeScale = 0f;
        else Time.timeScale = 1.0f;

        options.EnterOptions();
        options.ExitOptions();
    }
}

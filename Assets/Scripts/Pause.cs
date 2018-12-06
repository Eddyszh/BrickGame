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
        if (Input.GetKeyDown(KeyCode.Escape) ) OnPause();
	}

    void OnPause()
    {
        if (Time.timeScale == 1.0f)
        {
            Time.timeScale = 0f;
            pauseImage.SetActive(true);
        }
        else
        {
            Time.timeScale = 1.0f;
            pauseImage.SetActive(false);
            options.ExitOptions();
        }

    }
}

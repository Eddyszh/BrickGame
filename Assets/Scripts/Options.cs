using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    [SerializeField] GameObject optionsImage;
    [SerializeField] Slider slider;
    [SerializeField] Slider sfx_Slider;
    

	void Start ()
    {
        optionsImage.SetActive(false);
        slider.value = PlayerPrefs.GetFloat("volume", 1);
        sfx_Slider.value = PlayerPrefs.GetFloat("sfxVolume", 1);
	}

    public void EnterOptions()
    {
        optionsImage.SetActive(true);
    }

    public void ExitOptions()
    {
        optionsImage.SetActive(false);
    }

    public void SaveVolume()
    {
        PlayerPrefs.SetFloat("volume", slider.value);
        PlayerPrefs.SetFloat("sfxVolume", sfx_Slider.value);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    [SerializeField] GameObject optionsImage;

	void Start ()
    {
        optionsImage.SetActive(false);
	}

    public void EnterOptions()
    {
        optionsImage.SetActive(true);
    }

    public void ExitOptions()
    {
        optionsImage.SetActive(false);
    }
}

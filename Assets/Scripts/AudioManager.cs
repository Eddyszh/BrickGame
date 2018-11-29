using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] clips;

	void Start ()
    {
        DontDestroyOnLoad(gameObject);
	}

    public void ChangeMusic(int situation)
    {
        switch (situation)
        {
            case 1:
                audioSource.Stop();
                audioSource.PlayOneShot(clips[1]);
                break;
            case 2:
                audioSource.Stop();
                audioSource.PlayOneShot(clips[2]);
                break;
            case 3:
                audioSource.Stop();
                audioSource.PlayOneShot(clips[3]);
                break;
            case 0:
                audioSource.PlayOneShot(clips[0]);
                break;
            default:
                break;
        }
    }
}

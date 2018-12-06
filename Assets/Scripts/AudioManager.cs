using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource eventMusic;
    [SerializeField] AudioClip[] clips;

    public void ChangeLevelMusic(int level)
    {
        switch (level)
        {
            case 0:
                audioSource.Stop();
                audioSource.PlayOneShot(clips[0]);
                break;
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
            default:
                break;
        }
    }

    public void EventMusic(int character)
    {
        switch (character)
        {
            case 0:
                audioSource.Stop();
                eventMusic.PlayOneShot(clips[4]);
                break;
            case 1:
                audioSource.Stop();
                eventMusic.PlayOneShot(clips[5]);
                break;
            default:
                break;
        }
    }
}

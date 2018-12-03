using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] clips;

    static AudioManager instance;

    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<AudioManager>();

                if (instance == null)
                {
                    GameObject go = new GameObject(typeof(AudioManager).ToString());
                    go.AddComponent<AudioManager>();
                }
            }
            return instance;
        }
    }

    public void ChangeMusic(int situation)
    {
        switch (situation)
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
            case 4:
                audioSource.Stop();
                audioSource.PlayOneShot(clips[4]);
                break;
            case 5:
                audioSource.Stop();
                audioSource.PlayOneShot(clips[5]);
                break;
            default:
                break;
        }
    }
}

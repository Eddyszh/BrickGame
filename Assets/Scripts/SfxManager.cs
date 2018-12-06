using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{
    [SerializeField] AudioSource sfx_source;
    [SerializeField] AudioClip[] sfx;

    public void PlaySFX(int fire)
    {
        switch (fire)
        {
            case 0:
                sfx_source.PlayOneShot(sfx[0]);
                break;
            case 1:
                sfx_source.PlayOneShot(sfx[1]);
                break;
            default:
                break;
        }
    }
}

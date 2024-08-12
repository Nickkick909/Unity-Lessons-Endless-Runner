using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sky : MonoBehaviour
{
    [SerializeField] AudioClip nightSound;
    [SerializeField] AudioClip daySound;
    [SerializeField] AudioSource audioSrc;

    public void PlayNightSound()
    {
        audioSrc.clip = nightSound;
        audioSrc.Play();
    }

    public void PlayDaySound()
    {
        audioSrc.clip = daySound;
        audioSrc.Play();
    }
}

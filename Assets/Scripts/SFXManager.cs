using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    AudioSource sfxSrc;

    [SerializeField] AudioClip coinSFX;
    [SerializeField] AudioClip doubleJump;
    [SerializeField] AudioClip gameOver;
    [SerializeField] AudioClip jump;
    [SerializeField] AudioClip land;
    [SerializeField] AudioClip powerUpDoubleJump;
    [SerializeField] AudioClip powerUpShield;
    [SerializeField] AudioClip shieldBreak;

    void Start()
    {
        sfxSrc = GetComponent<AudioSource>();
    }

    public void PlaySFX(string clipName)
    {
        switch (clipName)
        {
            case "coin":
                sfxSrc.PlayOneShot(coinSFX);
                break;
            case "doubleJump":
                sfxSrc.PlayOneShot(doubleJump);
                break;
            case "gameOver":
                sfxSrc.PlayOneShot(gameOver);
                break;
            case "jump":
                sfxSrc.PlayOneShot(jump);
                break;
            case "land":
                sfxSrc.PlayOneShot(land);
                break;
            case "powerUpDoulbeJump":
                sfxSrc.PlayOneShot(powerUpDoubleJump);
                break;
            case "powerUpShield":
                sfxSrc.PlayOneShot(powerUpShield);
                break;
            case "shieldBreak":
                sfxSrc.PlayOneShot(shieldBreak);
                break;
        }
    }
}

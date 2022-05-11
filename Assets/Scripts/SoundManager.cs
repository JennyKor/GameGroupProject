using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Not actually used in the project
public class SoundManager : MonoBehaviour
{
    public static AudioClip shootSound;
    static AudioSource audioSrc;

    private void Start()
    {
        shootSound = Resources.Load<AudioClip>("Zap");


        audioSrc = GetComponent<AudioSource>(); 
    
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "shoot":
                audioSrc.PlayOneShot(shootSound);
                break;
        }
    }
}
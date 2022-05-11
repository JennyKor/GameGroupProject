using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadSkelDestroyer : MonoBehaviour
{


    public AudioClip deathClip;
    AudioSource audioSource;
    //Script to destroy the skelDeath prefab so that we don't get buried in dead enemies. The death sound for the skeleton is also player from here.

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destroyer());

    }


    IEnumerator destroyer()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(deathClip);
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}

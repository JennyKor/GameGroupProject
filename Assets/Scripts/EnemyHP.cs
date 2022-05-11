using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public int maxHP = 100;
    public int curHP = 100;
    Animator animator;
    public GameObject currentBullet;
    KillCounter killCounter;
    public int killCount = 0;
    public GameObject deathPrefab;
    public Transform enemyTransform;

    public AudioClip zapClip;
    AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {

        //hitSound = GetComponent<AudioSource>();
        killCounter = GameObject.FindWithTag("GameManager").GetComponent<KillCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (curHP < 1)

        {
            KillEnemy();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {

            curHP -= 40;
            //Playing the sound effect when the "bullet" hits the enemy
            //Using this way of playing the sound effect instead of the hitSound.Play(), because I wanted to have multiple sounds playing at the same time, but it still doesn't work they way I wanted it to.
            audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.PlayOneShot(zapClip);
            //Destroying the "bullet" that has collided with an enemy.
            Destroy(collision.gameObject);
            //hitSound.Play();

            //killCount++;
        }


        //Work around for an earlier bug, done by Fiona
        //if (killCount == 3)
        //{
        //    killCounter.IncreaseScore();
        //}
    }

    private void KillEnemy()
    {
        animator = GetComponent<Animator>();
        //Adds one to the kill counter
        killCounter.IncreaseScore();
        //Instantiating a deathSkel prefab in the place of the normal enemy skeleton that has the navmesh pathfinding
        Instantiate(deathPrefab, gameObject.transform.position, Quaternion.identity);

        Destroy(this.gameObject);

        animator.Play("SkelDie");
    }
}

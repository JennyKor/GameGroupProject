using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Rigidbody2D rb;
    private Staff staff;
    public float speed;

    public Vector2 direction;


    public AudioClip zap;
    AudioSource audioSource;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        staff = GameObject.FindGameObjectWithTag("Staff").GetComponent<Staff>();
        direction = staff.direction;
        direction.Normalize();
        rb.velocity = direction * speed;
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(zap);



    }

    public void Update()
    {

        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour
{
    public Vector2 direction;
    public GameObject bulletPrefab;
    public Transform spawnPos;
    private float shotTimer;
    public float timeBtwShots;
    public GameObject staffAnimation;

    public void Start()
    {
        staffAnimation.SetActive(false);
    }

    public void Update()
    {
        Vector2 staffPos = transform.position;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (mousePos - staffPos).normalized;
        transform.right = direction;

        shotTimer -= Time.deltaTime;

        if (Input.GetButtonDown("Fire1") || Input.GetButton("Fire1"))
        {
            if (shotTimer <= 0)
            {
                Shoot();

                staffAnimation.SetActive(true);
                Invoke("Setfalse", 0.2f);
            }

        }
    }

    public void Shoot()
    {
        shotTimer = timeBtwShots;
        Instantiate(bulletPrefab, spawnPos.position, Quaternion.identity);


    }

    void Setfalse()
    {
        staffAnimation.SetActive(false);
    }
}

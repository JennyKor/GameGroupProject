using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour
{
    private static ILogger logger = Debug.unityLogger;
    // Start is called before the first frame update
    public GameObject currentBullet;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Walls")
        {
            Destroy(currentBullet);
       
        }
     
    }
}

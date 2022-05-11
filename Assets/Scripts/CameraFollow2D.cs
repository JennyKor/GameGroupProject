using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float timeOffset;
    [SerializeField] Vector2 posOffset;

    //Camera boundaries
    [SerializeField] float leftLimit;
    [SerializeField] float rightLimit;
    [SerializeField] float bottomLimit;
    [SerializeField] float topLimit;

    private Vector3 velocity;

    // Update is called once per frame
    void Update()
    {
        // Camera's start position
        Vector3 startPos = transform.position;

        // Player's current position
        Vector3 endPos = player.transform.position;
        endPos.x += posOffset.x;
        endPos.y += posOffset.y;
        endPos.z = -10;

        transform.position = Vector3.Lerp(startPos, endPos, timeOffset * Time.deltaTime);

        //smoothdamping
        //transform.position = Vector3.SmoothDamp(startPos, endPos, ref velocity, timeOffset);

        // Clamping camera's x- and y-axis positions within given limits
        transform.position = new Vector3
            (
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(transform.position.y, bottomLimit, topLimit),
            transform.position.z
            );
    }
}

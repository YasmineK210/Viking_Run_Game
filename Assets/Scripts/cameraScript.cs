using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public Transform player;
    public float distance = 0.1f;
    public float delay = 0.02f;
    public float height = 2.2f;


    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 cameraMove = player.position - player.forward * distance;
        cameraMove.y += height;
        transform.position += (cameraMove - transform.position) * delay;

        transform.LookAt(player.transform);
    }
}

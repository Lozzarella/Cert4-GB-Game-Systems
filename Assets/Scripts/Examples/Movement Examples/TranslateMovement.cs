using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateMovement : MonoBehaviour
{
    public float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        //teleports forward every update frame
        //ignores other objects/colliders
        //adjusts position/speed based on delta time
        //move forward by speed over time between frames to normalise time
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}

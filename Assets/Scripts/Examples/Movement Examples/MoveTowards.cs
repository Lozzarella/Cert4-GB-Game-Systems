using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //moves towards a specific point in 3D space
        //teleports forward every update frame
        //ignores other objects/colliders
        //adjusts position/speed based on delta time
        //
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 0, 50), speed * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLight : MonoBehaviour
{

    public float rotationSpeed;


    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0f, 0f, rotationSpeed);
        if (transform.rotation.z==360)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}

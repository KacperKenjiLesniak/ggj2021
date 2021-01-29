using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLight : MonoBehaviour
{
    public float rotationSpeed;

    void Update()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
        if (transform.rotation.z >= 360f)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}
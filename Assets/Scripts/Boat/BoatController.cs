using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    
    [SerializeField] private float accel = 1.5f;
    [SerializeField] private float turnSpeed = 1f;
    [SerializeField] private float maxSpeed = 3f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate () {

        if (Input.GetAxis("Vertical") != 0)
        {
            rb.AddRelativeForce((Input.GetAxis("Vertical") > 0 ? Vector2.up : Vector2.down) * accel);

            if (rb.velocity.magnitude > maxSpeed)
            {
                rb.velocity = rb.velocity.normalized * maxSpeed;
            }
        }

        if (Input.GetAxis("Horizontal") != 0)
        {
            var scale = Mathf.Lerp(0f, turnSpeed, rb.velocity.magnitude / maxSpeed);
            rb.AddTorque(-Input.GetAxis("Horizontal") * scale);
        }
    }
}

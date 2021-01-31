using System;
using MutableObjects.Bool;
using MutableObjects.Vector3;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    
    [SerializeField] private float acceleration = 1.5f;
    [SerializeField] private float turnSpeed = 1f;
    [SerializeField] private float maxSpeed = 3f;
    [SerializeField] private MutableBool movementActive;
    [SerializeField] private MutableVector3 boatPosition;
    [SerializeField] private AudioSource rowingSource;
    [SerializeField] private float boatRowingVolume = 0.6f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movementActive.Value = true;
    }

    private void Update()
    {
        boatPosition.Value = transform.position + new Vector3(0f, -3f, 0f);
    }

    void FixedUpdate () {
        if (movementActive.Value)
        {
            if (Input.GetAxis("Vertical") != 0)
            {
                rb.AddRelativeForce((Input.GetAxis("Vertical") > 0 ? Vector2.up : Vector2.down) * acceleration);

                if (rb.velocity.magnitude > maxSpeed)
                {
                    rb.velocity = rb.velocity.normalized * maxSpeed;
                }
                rowingSource.volume = boatRowingVolume;
            }
            else
            {
                rowingSource.volume = 0f;
            }

            if (Input.GetAxis("Horizontal") != 0)
            {
                var scale = Mathf.Lerp(0.5f, turnSpeed, rb.velocity.magnitude / maxSpeed);
                rb.AddTorque(-Input.GetAxis("Horizontal") * scale);
            }
        }
    }
}

using MutableObjects.Bool;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    
    [SerializeField] private float acceleration = 1.5f;
    [SerializeField] private float turnSpeed = 1f;
    [SerializeField] private float maxSpeed = 3f;
    [SerializeField] private MutableBool movementActive;
    
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
            }

            if (Input.GetAxis("Horizontal") != 0)
            {
                var scale = Mathf.Lerp(0f, turnSpeed, rb.velocity.magnitude / maxSpeed);
                rb.AddTorque(-Input.GetAxis("Horizontal") * scale);
            }
        }
    }
}

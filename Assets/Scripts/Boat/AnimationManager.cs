using System.Collections;
using System.Collections.Generic;
using MutableObjects.Bool;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] private MutableBool movementActive;
    [SerializeField] private Animator animator;
    // Start is called before the first frame update


    // Update is called once per frame
    void FixedUpdate()
    {
        if (movementActive.Value)
        {
            if (Input.GetAxis("Vertical") > 0.1 || Input.GetAxis("Vertical") < -0.1 )
            {
                animator.SetBool("isMoving", true);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }



            animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Vertical")));
        }

        

    }
}

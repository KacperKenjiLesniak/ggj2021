using System;
using System.Collections;
using System.Collections.Generic;
using MutableObjects.Bool;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] private MutableBool movementActive;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (movementActive.Value)
        {
            if (Input.GetAxis("Vertical") > 0.1 || Input.GetAxis("Vertical") < -0.1)
            {
                animator.SetBool("isMoving", true);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }

            animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Vertical")));
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }
}
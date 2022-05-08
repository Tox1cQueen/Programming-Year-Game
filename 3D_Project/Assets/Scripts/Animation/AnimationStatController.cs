using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStatController : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //conditions for the animation controller
        bool Forward = Input.GetKey("w");
        bool Backward = Input.GetKey("s");
        bool Right = Input.GetKey("d");
        bool Left = Input.GetKey("a");
        //the logit for the controller
        if (Forward)
        {
            animator.SetBool("IsMoving", true);
        }
        if (!Forward)
        {
            animator.SetBool("IsMoving", false);
        }

        if (Backward)
        {
            animator.SetBool("IsMoving", true);
        }
        if (!Forward && !Backward)
        {
            animator.SetBool("IsMoving", false);
        }

        if (Right)
        {
            animator.SetBool("IsRight", true);
            animator.SetBool("IsMoving", true);
        }
        if (!Right)
        {
            animator.SetBool("IsRight", false);
        }

        if (Left)
        {
            animator.SetBool("IsLeft", true);
            animator.SetBool("IsMoving", true);
        }
        if (!Left)
        {
            animator.SetBool("IsLeft", false);
        }
    }

}

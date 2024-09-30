using CraftingAnims;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAnimatorContollers : MonoBehaviour
{
    public UnityEvent OnFootR = new UnityEvent();
    public UnityEvent OnFootL = new UnityEvent();
    public UnityEvent OnStrike = new UnityEvent();

    //public CrafterController crafterController;
    private Animator animator;

    void Awake()
    {
        //crafterController = GetComponentInParent<CrafterController>();
        animator = GetComponent<Animator>();
    }

    public void FootR()
    {
        OnFootR.Invoke();
    }

    public void FootL()
    {
        OnFootL.Invoke();
    }

    public void Strike()
    {
        OnStrike.Invoke();
    }

    // Used for animations that contain root motion to drive the character’s
    // position and rotation using the “Motion” node of the animation file.
    //void OnAnimatorMove()
    //{
    //    if (animator)
    //    {
    //        if (crafterController)
    //        {
    //            if (crafterController.isLocked)
    //            {
    //                transform.parent.rotation = animator.rootRotation;
    //                transform.parent.position += animator.deltaPosition;
    //            }
    //        }
    //    }
    //}
}

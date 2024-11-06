using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    private Animator anim;
    private string Walk_Animtion = "Walk";
    private string walkParameter = "WalkParam";
    private string attackParameter = "Attack";
    private string jumpParameter = "JumpParam";

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void WalkAnim()
    {
        anim.Play("Walk");
    }


    public void PlayerWalk (bool walk)
    {
        anim.SetBool(walkParameter, walk);
    }


    public void PlayerAttack()
    {
        anim.SetBool(attackParameter, true);
    }


    public void PlayerAttackEnd()
    {
        anim.SetBool(attackParameter, false);
    }

    

    public void Jumped(bool hasJumped)
    {
        anim.SetBool(jumpParameter, hasJumped);
    }
    
}
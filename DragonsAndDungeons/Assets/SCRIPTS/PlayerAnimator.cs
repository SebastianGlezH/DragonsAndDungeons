using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    private Animator anim;
    // private string Walk_Animtion = "Walk";
    // private string walkParam = "Walking";
    private string walkParam = "velocidad";
    private string attackParameter = "Attack";
    private string jumpParameter = "JumpParam";

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // public void WalkAnim()
    // {
    //     anim.Play("Walking");
    // }


    // public void PlayerWalk (bool walk)
    // {
    //     anim.SetBool(walkParam, walk);
    //     Debug.Log(walk);
    // }

    public void PlayerWalk (float walk)
    {
        
        anim.SetFloat(walkParam, walk);
        // Debug.Log(walk);
    }


    public void PlayerAttack()
    {
        anim.Play("Attack");
        // anim.SetBool(attackParameter, true);
        // PlayerAttackEnd();
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

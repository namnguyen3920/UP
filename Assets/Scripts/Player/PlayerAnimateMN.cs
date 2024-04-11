using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimateMN
{
    /*PlayerController controller;
    private const string IS_GROUND = "isGround";
    private const string IS_JUMPING = "isJumping";
    private const string IS_WALLSLIDING = "isWallSliding";
    private const string IS_DEAD = "Death";*/

    /*public void PlayerAnimationUpdate()
    {
        *//*controller.AnimationFloatControl();
        controller.AnimationTriggerControl();
        controller.AnimationBoolControl();*//*
        AnimationBoolControl();
        AnimationFloatControl();
        AnimationTriggerControl();
    }

    private void AnimationBoolControl()
    {
        anim.SetBool(IS_GROUND, controller.IsGround);
        anim.SetBool(IS_JUMPING, controller.IsJumping());
        anim.SetBool(IS_WALLSLIDING, controller.IsWallSliding());
    }

    private void AnimationFloatControl()
    {
        anim.SetFloat("yVelocity", rb.velocity.y);
    }

    private void AnimationTriggerControl()
    {
        anim.SetTrigger(IS_DEAD);
    }*/
    

    /*private PlayerMovement player;
    [SerializeField] Animator anim;

    private void Update()
    {
        AnimationBoolControl();
        AnimationTriggerControl();
    }

    private void AnimationBoolControl()
    {
        AnimationMN.d_Instance.SetBoolAction(anim, IS_Ground, player.IsGround());
        AnimationMN.d_Instance.SetBoolAction(anim, IS_JUMPING, player.IsJumping());
        AnimationMN.d_Instance.SetBoolAction(anim, IS_WALLSLIDING, player.IsWallSliding());
    }

    private void AnimationTriggerControl()
    {
        AnimationMN.d_Instance.SetTriggerAction(anim, IS_DEAD);
    }*/
}

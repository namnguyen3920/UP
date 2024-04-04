using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAnimateMN : PlayerController
{
    [SerializeField] protected Animator player_anim;

    protected override void Update()
    {
        base.Update();
        AnimateUpdate += AnimationBoolControl;
        AnimateUpdate += AnimationTriggerControl;
    }
    private void AnimationBoolControl()
    {
        AnimationMN.d_Instance.SetBoolMovement(player_anim, "isGround", isMoving);
        AnimationMN.d_Instance.SetBoolMovement(player_anim, "isGround", grounded);
        AnimationMN.d_Instance.SetBoolMovement(player_anim, "isJumping", isJumping);
        AnimationMN.d_Instance.SetBoolMovement(player_anim, "isWallSliding", isTouchingWall);        
    }

    private void AnimationTriggerControl()
    {
        if(isDead) { AnimationMN.d_Instance.SetTriggerDead(player_anim, "Death"); }        
    }
}

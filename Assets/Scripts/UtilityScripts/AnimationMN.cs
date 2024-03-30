using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMN : Singleton_Mono_Method<AnimationMN>
{

    [SerializeField] Animator enemy_anim;
    [SerializeField] Animator player_anim;

    public void EnemyAnimUpdate_Dead()
    {
        /*player_anim.SetBool("onGround", PlayerController.Instance.OnGround());
        player_anim.SetBool("onWall", PlayerController.Instance.OnWall());
        player_anim.SetBool("onRightWall", PlayerController.Instance.OnRightWall());
        //anim.SetBool("wallSlide", playerMovement.wallSlide);
        player_anim.SetBool("canMove", playerMovement.canMove);*/

        enemy_anim.SetTrigger("Dead");
    }

    public void PlayerAnimUpdate_Dead()
    {
        player_anim.SetTrigger("Dead");
    }
}

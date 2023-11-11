using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{

    Animator anim;
    PlayerMovement playerMovement;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    //void Start()
    //{
    //    anim = GetComponent<Animator>();
    //    playerMovement = GetComponent<PlayerMovement>();
    //    spriteRenderer = GetComponent<SpriteRenderer>();
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    anim.SetBool("onGround", PlayerController.Instance.OnGround());
    //    anim.SetBool("onWall", PlayerController.Instance.OnWall());
    //    anim.SetBool("onRightWall", PlayerController.Instance.OnRightWall());
    //    //anim.SetBool("wallSlide", playerMovement.wallSlide);
    //    anim.SetBool("canMove", playerMovement.canMove);
    //}

    ////public void OnWallFlip(int side)
    ////{

    ////    if (playerMovement.wallSlide)
    ////    {
    ////        if (side == -1 && spriteRenderer.flipX)
    ////            return;

    ////        if (side == 1 && !spriteRenderer.flipX)
    ////        {
    ////            return;
    ////        }
    ////    }

    ////    bool state = (side == 1) ? false : true;
    ////    spriteRenderer.flipX = state;
    ////}

    //public void SetMovementNumerical(float y)
    //{
    //    anim.SetFloat("yAxis", y);
    //}

    //public void SetTrigger(string trigger)
    //{
    //    anim.SetTrigger(trigger);
    //}
}

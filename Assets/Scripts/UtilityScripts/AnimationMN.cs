using UnityEngine;

public class AnimationMN : Singleton_Method<AnimationMN>
{
    public void SetTriggerAction(Animator anim, string d_trigger)
    {
        anim.SetTrigger(d_trigger);
    }

    public void SetBoolAction(Animator anim, string d_action, bool value) 
    {
        anim.SetBool(d_action, value);
    }
}

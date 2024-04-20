using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
    private const string IS_COLLECTED = "collected";

    [SerializeField] protected Animator obj_anim;
    [SerializeField] protected Transform coinPrefab;

    protected void CollectAnim(Animator obj_anim)
    {
        AnimationMN.d_Instance.SetTriggerAction(obj_anim, IS_COLLECTED);
    }

    public void CoinCollected(Transform obj_prefab)
    {
        PoolManager.d_Instance.GetCoin(obj_prefab);
    }
}

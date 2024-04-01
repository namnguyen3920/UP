using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEnemiesPooling : Singleton_Mono_Method<DeadEnemiesPooling>
{
    [SerializeField] protected List<Transform> DeadEnemiesPool = new();

    public void ReturnEnemiesToPool(Transform d_enemies)
    {
        DeadEnemiesPool.Add(d_enemies);
        foreach (var e in DeadEnemiesPool)
        {
            InactiveDeadEnemy(DeadEnemiesPool);
        }
    }



    public virtual void InactiveDeadEnemy(List<Transform> pools)
    {
        foreach(Transform e in pools)
        {
            e.gameObject.SetActive(false);
        }
    }
}

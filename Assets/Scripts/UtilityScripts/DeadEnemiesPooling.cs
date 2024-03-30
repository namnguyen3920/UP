using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEnemiesPooling : MonoBehaviour
{
    [SerializeField] protected List<GroundEnemies> DeadEnemiesPool;

    public void SetEnemiesInactive(GroundEnemies d_enemies)
    {
        DeadEnemiesPool.Add(d_enemies);
        d_enemies.gameObject.SetActive(false);
        Debug.Log("Enemy added to pool");
    }

    
}

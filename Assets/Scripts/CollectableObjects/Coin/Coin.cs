using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : Collectable
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Collect!");
            MusicMN.d_Instance.PlaySFX(SoundType.CoinCollected);
            CoinCollected(transform);
        }
    }
}

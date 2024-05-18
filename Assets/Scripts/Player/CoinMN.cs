using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMN : MonoBehaviour
{
    public int coin {  get; private set; }
    public void AddCoin(int amount)
    {
        coin += amount;
    }
}

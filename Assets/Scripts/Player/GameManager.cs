using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinText;
    /*[SerializeField] int coin_amount = 0;*/
    void Update()
    {
        DisplayCoinValue();
    }
    void DisplayCoinValue()
    {
        int coin = PoolManager.d_Instance.GetCoinAmount();
        coinText.text = coin.ToString();
    }
}

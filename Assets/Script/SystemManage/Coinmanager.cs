using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coinmanager : MonoBehaviour
{
    [SerializeField]private CoinData coinData;

    public static Coinmanager Instance;

    void Awake()
    {
        Instance = this;
    }

    public int GetCoin()
    {
        return coinData.coins;
    }

    public void ReduceCoin(int amount)
    {
        coinData.coins -= amount;
    }

    public void AddCoin(int amount)
    {
        coinData.coins += amount;
    }
}

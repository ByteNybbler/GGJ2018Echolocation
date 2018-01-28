// Author(s): Paul Calande
// Coin controller script.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinController : MonoBehaviour
{
    public delegate void AllCoinsCollectedHandler();
    public event AllCoinsCollectedHandler AllCoinsCollected;

    [SerializeField]
    [Tooltip("Reference to the coins text.")]
    Text textCoins;

    int coinCount;
    int coinsCollected;

    private void Awake()
    {
        CountCoins();
    }

    private void CountCoins()
    {
        Coin[] coins = FindObjectsOfType<Coin>();
        coinCount = coins.Length;
        coinsCollected = 0;
        foreach (Coin coin in coins)
        {
            coin.Collected += Coin_Collected;
        }
        UpdateCoinStatus();
    }

    private void Coin_Collected()
    {
        ++coinsCollected;
        UpdateCoinStatus();
    }

    private void UpdateCoinStatus()
    {
        if (coinsCollected == coinCount)
        {
            OnAllCoinsCollected();
        }
        UpdateCoinText();
    }

    private void UpdateCoinText()
    {
        textCoins.text = "COINS: " + coinsCollected + "/" + coinCount;
    }

    private void OnAllCoinsCollected()
    {
        if (AllCoinsCollected != null)
        {
            AllCoinsCollected();
        }
    }
}
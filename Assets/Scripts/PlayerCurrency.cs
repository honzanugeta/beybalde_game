using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCurrency : MonoBehaviour
{
    private int sigmaCoins = 0; // The currency of the game
    [SerializeField] private TextMeshProUGUI coinsTMP;


    internal void AddCoins(int coins)
    {
        sigmaCoins += coins;
        SaveCoins();
    }

    internal void RemoveCoins(int coins)
    {
        sigmaCoins -= coins;
        SaveCoins();
    }

    internal bool CanBuy(int price)
    {
        return sigmaCoins >= price;
    }

    #region Datamanager
    private void SaveCoins()
    {
        UpdateCoinsText();
        DataManager.instance.SaveCoins(sigmaCoins);
        Debug.Log("Coins saved: " + sigmaCoins);
    }

    internal void LoadCoins()
    {
        sigmaCoins = DataManager.instance.LoadCoins();
        UpdateCoinsText();
        Debug.Log("Coins loaded: " + sigmaCoins);
    }

    private void UpdateCoinsText()
    {
        coinsTMP.text = "Coins " + sigmaCoins.ToString();
    }
    #endregion
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCurrency : MonoBehaviour
{
    private int sigmaCoins = 0; // The currency of the game

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
        DataManager.instance.SaveCoins(sigmaCoins);
        Debug.Log("Coins saved: " + sigmaCoins);
    }

    internal void LoadCoins()
    {
        sigmaCoins = DataManager.instance.LoadCoins();
        Debug.Log("Coins loaded: " + sigmaCoins);
    }
    #endregion
}

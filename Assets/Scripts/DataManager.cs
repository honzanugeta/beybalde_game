using SecPlayerPrefs;
using System;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private string coinsKey = "sigmaCoins6969"; // The key for the coins in the PlayerPrefs

    public static DataManager instance;

    private PlayerCurrency playerCurrency;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

        playerCurrency = GetComponent<PlayerCurrency>();
    }

    internal void UnlockPart(string partName, int cost)
    {
        string finalPartName = FormatPartName(partName);
        SecurePlayerPrefs.SetBool(finalPartName, true);
        Debug.Log($"Part {finalPartName} unlocked for {cost} coins");
    }

    //Testing Method to lock parts
    internal void LockPart(string partName)
    {
        string finalPartName = FormatPartName(partName);
        SecurePlayerPrefs.SetBool(finalPartName, false);
        Debug.Log($"Part {finalPartName} locked");
    }

    internal bool IsPartUnlocked(string partName)
    {
        string finalPartName = FormatPartName(partName);
        return SecurePlayerPrefs.GetBool(finalPartName);
    }

    internal void SaveCoins(int sigmaCoins)
    {
        SecurePlayerPrefs.SetInt(coinsKey, sigmaCoins);
    }

    internal int LoadCoins()
    {
        return SecurePlayerPrefs.GetInt(coinsKey);
    }
    private string FormatPartName(string partName)
    {
        return partName.Replace(" ", "_");
    }
}

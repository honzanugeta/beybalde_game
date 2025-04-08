using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    public static LobbyManager instance;

    private Inventory inventory;
    private PlayerCurrency playerCurrency;
    private PartsStorage partsStorage;

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

        inventory = FindAnyObjectByType<Inventory>();
        playerCurrency = FindAnyObjectByType<PlayerCurrency>();
        partsStorage = FindAnyObjectByType<PartsStorage>();
    }

    private void Start()
    {
        playerCurrency.LoadCoins();

        // Testing method to lock all parts
        LockAllParts();
    }

    private void LockAllParts()
    {
        Debug.Log($"Locking all parts... {partsStorage.PartList.Count}");
        foreach (PartSO part in partsStorage.PartList)
        {
            DataManager.instance.LockPart(part.partName);
        }
    }

    internal void OpenInventory(bool open)
    {
        inventory.CanvasOpen(open);
    }
}

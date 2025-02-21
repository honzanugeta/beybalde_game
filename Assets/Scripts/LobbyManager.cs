using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    public static LobbyManager instance;

    private Inventory inventory;

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
    }

    internal void OpenInventory(bool open)
    {
        inventory.CanvasOpen(open);
    }


}

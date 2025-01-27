using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VInspector;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Transform bladesGrid;
    [SerializeField] private Transform coresGrid;
    [SerializeField] private Transform rachetsGrid;

    [SerializeField] private PartUI partUiPrefab;

    [SerializeField] private SerializedDictionary<PartSO.PartRarity, Color> rarityColors;

    private PartsStorage partsStorage;

    private void Start()
    {
        partsStorage = GetComponent<PartsStorage>();
        PopulateInventory();
    }

    private void PopulateInventory()
    {
        Debug.Log($"Populating inventory... {partsStorage.PartList.Count}x");
        foreach (PartSO part in partsStorage.PartList)
        {
            PartUI partUI = null;
            switch (part.type)
            {
                case PartSO.PartType.Disk:
                    partUI = Instantiate(partUiPrefab, bladesGrid);
                    break;
                case PartSO.PartType.Ratchet:
                    partUI = Instantiate(partUiPrefab, rachetsGrid);
                    break;
                case PartSO.PartType.Bit:
                    partUI = Instantiate(partUiPrefab, coresGrid);
                    break;
            }

            partUI.SetIcon(part.icon);

            Color bgColor = rarityColors[part.rarity];
            partUI.SetRarity(bgColor);
        }
    }
}

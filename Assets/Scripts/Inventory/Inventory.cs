using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using VInspector;

public class Inventory : MonoBehaviour
{
    [Header("UI Storage")]
    [SerializeField] private Transform bladesGrid;
    [SerializeField] private Transform coresGrid;
    [SerializeField] private Transform rachetsGrid;

    [Header("Selected Storage UI")]
    [SerializeField] private Image selectedBladeUI;
    [SerializeField] private Image selectedCoreUI;
    [SerializeField] private Image selectedRachetUI;

    [Header("Selected Storage")]
    [SerializeField, ReadOnly] private PartSO selectedBlade;
    [SerializeField, ReadOnly] private PartSO selectedCore;
    [SerializeField, ReadOnly] private PartSO selectedRachet;

    [SerializeField] private PartUI partUiPrefab;

    [SerializeField] private SerializedDictionary<PartSO.PartRarity, Color> rarityColors;

    private Dictionary<PartSO, PartUI> partUIDict = new Dictionary<PartSO, PartUI>();

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

            partUIDict.Add(part, partUI); // Add to dictionary
            partUI.SetInventory(this);

            partUI.SetIcon(part.icon);
            Color bgColor = rarityColors[part.rarity];
            partUI.SetRarity(bgColor);
        }
    }

    internal void SelectPart(PartUI partUI)
    {
        for (int i = 0; i < partsStorage.PartList.Count; i++)
        {
            if (partUIDict[partsStorage.PartList[i]] == partUI)
            {
                UpdateSelectedPart(partsStorage.PartList[i]);
                break;
            }
        }
    }

    private void UpdateSelectedPart(PartSO part)
    {
        Image image = null;

        switch (part.type)
        {
            case PartSO.PartType.Disk:
                selectedBlade = part;
                UpdateUI(selectedBladeUI, selectedBlade.icon, selectedBlade.rarity);
                break;

            case PartSO.PartType.Ratchet:
                selectedRachet = part;
                UpdateUI(selectedRachetUI, selectedRachet.icon, selectedRachet.rarity);
                break;

            case PartSO.PartType.Bit:
                selectedCore = part;
                UpdateUI(selectedCoreUI, selectedCore.icon, selectedCore.rarity);
                break;
        }
    }

    private void UpdateUI(Image uiElement, Sprite icon, PartSO.PartRarity rarity)
    {
        uiElement.color = rarityColors[rarity];
        Image image = uiElement.GetComponentsInChildren<Image>(true)[1];
        Debug.Log(image.name);
        image.sprite = icon;
    }
}

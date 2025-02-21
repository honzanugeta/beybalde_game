using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VInspector;

public class Inventory : MonoBehaviour
{
    [Header("UI Storage")]
    [SerializeField] private Transform bladesGrid;
    [SerializeField] private Transform coresGrid;
    [SerializeField] private Transform rachetsGrid;
    [SerializeField] private PartUI partUiPrefab;
    [SerializeField] private Transform canvasUI;

    [Header("Selected Storage UI")]
    [SerializeField] private Image selectedBladeUI;
    [SerializeField] private Image selectedCoreUI;
    [SerializeField] private Image selectedRachetUI;

    [Header("Selected Storage")]
    [SerializeField, ReadOnly] private PartSO selectedBlade;
    [SerializeField, ReadOnly] private PartSO selectedCore;
    [SerializeField, ReadOnly] private PartSO selectedRachet;

    [Header("Part Info UI")]
    [SerializeField] private TextMeshProUGUI partNameTMP;
    [SerializeField] private TextMeshProUGUI partTypeTMP;

    [Header("Stats")]
    [SerializeField] private StatUI statUIPrefab;
    [SerializeField] private Transform statDoc;
    [SerializeField] private GameObject cover;
    [SerializeField] private float fadeTime = 1.2f;

    private bool coverIsHidden = false;

    private float maxDamageInfo;
    private float maxHpInfo;
    private float maxSpeedInfo;
    private float maxRotationInfo;
    private float maxKnockbackInfo;

    private List<StatUI> statsUIs = new List<StatUI>();


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
        //Debug.Log($"Populating inventory... {partsStorage.PartList.Count}x");
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

            maxDamageInfo = Mathf.Max(maxDamageInfo, part.damage);
            maxHpInfo = Mathf.Max(maxHpInfo, part.hp);
            maxSpeedInfo = Mathf.Max(maxSpeedInfo, part.speed);
            maxRotationInfo = Mathf.Max(maxRotationInfo, part.rotationTime);
            maxKnockbackInfo = Mathf.Max(maxKnockbackInfo, part.knockbackForce);

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
                GlobalVariables.SelectedBlade = selectedBlade;
                break;

            case PartSO.PartType.Ratchet:
                selectedRachet = part;
                UpdateUI(selectedRachetUI, selectedRachet.icon, selectedRachet.rarity);
                GlobalVariables.SelectedRachet = selectedRachet;

                break;

            case PartSO.PartType.Bit:
                selectedCore = part;
                UpdateUI(selectedCoreUI, selectedCore.icon, selectedCore.rarity);
                GlobalVariables.SelectedCore = selectedCore;
                break;

        }
        UpdatePartInfoUI(part);

    }

    private void UpdatePartInfoUI(PartSO part)
    {
        if (rarityColors.TryGetValue(part.rarity, out Color rarityColor))
        {
            // Convert color to hex format
            string colorHex = ColorUtility.ToHtmlStringRGB(rarityColor);

            // Set text with only part.rarity colored
            partNameTMP.text = $"{part.partName} <color=#{colorHex}>({part.rarity})</color>";
        }
        else
        {
            // Fallback if rarity is not found in the dictionary
            partNameTMP.text = $"{part.partName} ({part.rarity})";
        }

        partTypeTMP.text = part.type.ToString();

        if (!coverIsHidden)
        {
            coverIsHidden = true;
            StartCoroutine(FadeCover(fadeTime));
        }

        ClearPartInfoStats();
        CreatePartInfoStats(part);
    }

    private IEnumerator FadeCover(float fadeTime)
    {
        float elapsedTime = 0f;
        Image cover = this.cover.GetComponent<Image>();
        CanvasGroup canvasGroup = cover.GetComponent<CanvasGroup>();

        Color startColor = cover.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0f);

        float startAlpha = canvasGroup.alpha;
        float endAlpha = 0f;

        while (elapsedTime < fadeTime)
        {
            float t = elapsedTime / fadeTime;
            cover.color = Color.Lerp(startColor, endColor, t);
            canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        cover.color = endColor;
        canvasGroup.alpha = endAlpha;
    }


    private void ClearPartInfoStats()
    {
        foreach (StatUI statUI in statsUIs)
        {
            Destroy(statUI.gameObject);
        }
        statsUIs.Clear();
    }

    private void CreatePartInfoStats(PartSO part)
    {
        CreateStatUI("Damage", part.damage, maxDamageInfo);
        CreateStatUI("HP", part.hp, maxHpInfo);
        CreateStatUI("Speed", part.speed, maxSpeedInfo);
        CreateStatUI("Rotation", part.rotationTime, maxRotationInfo);
        CreateStatUI("Knockback", part.knockbackForce, maxKnockbackInfo);
    }

    private void CreateStatUI(string statName, float statValue, float maxValue)
    {
        StatUI statUI = Instantiate(statUIPrefab, statDoc);
        statUI.SetStat(statName, statValue, maxValue, new Color32(0, 128, 255, 255));
        statsUIs.Add(statUI);
    }

    private void UpdateUI(Image uiElement, Sprite icon, PartSO.PartRarity rarity)
    {
        uiElement.color = rarityColors[rarity];
        Image image = uiElement.GetComponentsInChildren<Image>(true)[1];
        image.sprite = icon;

        TextMeshProUGUI text = uiElement.GetComponentInChildren<TextMeshProUGUI>(true);
        text.gameObject.SetActive(false);
    }

    public void CanvasOpen(bool open)
    {
        canvasUI.gameObject.SetActive(open);
    }
}

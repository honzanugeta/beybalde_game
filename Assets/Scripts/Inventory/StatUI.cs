using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI statName;
    [SerializeField] private Image statFill;


    internal void SetStat(string name, float fillAmount, float maxAmount, Color color)
    {
        SetStatName(name, fillAmount);
        SetStatFill(fillAmount, maxAmount);
        SetStatColor(color);
    }
    private void SetStatName(string name,float value)
    {
        statName.text = $"{name} - {value}";
    }

    private void SetStatFill(float fillAmount, float maxAmount)
    {
        statFill.fillAmount = fillAmount / maxAmount;
    }

    private void SetStatColor(Color color)
    {
        statFill.color = color;
    }
}

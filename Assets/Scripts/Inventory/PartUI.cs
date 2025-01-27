using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartUI : MonoBehaviour
{
    [SerializeField] private Image icon;
    internal void SetIcon(Sprite newIcon)
    {
        icon.sprite = newIcon;
    }

    internal void SetRarity(Color newColor)
    {
        Image bg = GetComponent<Image>();
        bg.color = newColor;
    }
}


using UnityEngine;
using UnityEngine.UI;

public class PartUI : MonoBehaviour
{
    [SerializeField] private Image icon;

    private Button button;
    private Inventory inventory;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }
    internal void SetIcon(Sprite newIcon)
    {
        icon.sprite = newIcon;
    }

    internal void SetInventory(Inventory newInventory)
    {
        inventory = newInventory;
    }

    internal void SetRarity(Color newColor)
    {
        Image bg = GetComponent<Image>();
        bg.color = newColor;
    }

    private void OnButtonClick()
    {
        inventory.SelectPart(this);
    }
}


using UnityEngine;
using UnityEngine.UI;

public class PartUI : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] public AudioClip clickSound;
    private AudioSource audioSource;

    private Button button;
    private Inventory inventory;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
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
        PlayClickSound();

    }
    void PlayClickSound()
    {
        if (clickSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }
    
}

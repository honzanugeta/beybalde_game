using System.Collections.Generic;
using UnityEngine;
using VInspector;

public class PartsStorage : MonoBehaviour
{
    [SerializeField, ReadOnly] private List<PartSO> partList = new List<PartSO>();
    internal List<PartSO> PartList => partList;

    private void Awake()
    {
        LoadParts();
    }

    private void LoadParts()
    {
        // Load all PartSO from "Parts" and its subfolders
        PartSO[] loadedParts = Resources.LoadAll<PartSO>("Parts");

        if (loadedParts.Length > 0)
        {
            partList.AddRange(loadedParts);
            Debug.Log($"Loaded {loadedParts.Length} parts SO :).");
        }
        else
        {
            Debug.LogWarning("No parts found in Resources/Parts/.");
        }
    }
}

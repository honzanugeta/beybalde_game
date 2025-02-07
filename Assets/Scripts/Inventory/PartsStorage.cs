using System.Collections.Generic;
using UnityEngine;

public class PartsStorage : MonoBehaviour
{
    [SerializeField]private List<PartSO> partList = new List<PartSO>();
    internal List<PartSO> PartList => partList;


}

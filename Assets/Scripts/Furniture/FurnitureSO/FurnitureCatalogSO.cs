using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FurnitureCatalogSO : ScriptableObject
{
    [SerializeField] List<FurnitureSO> furnitureCatalog = new List<FurnitureSO>();

    public List<FurnitureSO> FurnitureCatalog
    {
        get { return furnitureCatalog; }
    }
}

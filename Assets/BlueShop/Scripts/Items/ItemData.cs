using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Data", menuName = "Item Data")]
public class ItemData : ScriptableObject
{
    public string name;
    public Sprite icon;
    public int price;
    public GameObject itemPrefab;
}

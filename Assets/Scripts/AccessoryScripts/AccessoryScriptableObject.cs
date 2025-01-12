using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AccessoryScriptableObject", menuName = "ScriptableObjects/Accessory", order = 1)]
public class AccessoryScriptableObject : ScriptableObject
{
    public string accessoryName;
    public int accessoryID;
    public Sprite accessorySprite;
    public GameObject prefab;
}

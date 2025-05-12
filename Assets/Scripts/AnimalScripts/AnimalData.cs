using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[System.Serializable]
public class AnimalData
{
    public int animalId;
    public int ownerId;
    public string animalPrefabPath;
    public float washingTime;
    public float stuffingTime;
    public AccessoryData eye;
    public List<AccessoryData> accessories;

    public GameObject LoadPrefab()
    {
        return Resources.Load<GameObject>(animalPrefabPath);
    }
}

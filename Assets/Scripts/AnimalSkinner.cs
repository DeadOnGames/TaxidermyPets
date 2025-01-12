using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AnimalSkinner : MonoBehaviour
{
    public GameObject skinnedAnimalPrefab;

    public void SkinAnimal()
    {
        SpawnPrefab();
    }

    public void SpawnPrefab()
    {
        if (skinnedAnimalPrefab != null)
        {
            Instantiate(skinnedAnimalPrefab, this.transform.position, this.transform.rotation);
            Debug.Log("Skinned prefab spawned!");
        }
        else
        {
            Debug.LogWarning("No prefab assigned to spawn!");
        }
    }
}

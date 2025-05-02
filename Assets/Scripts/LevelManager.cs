using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public AnimalDataManager animalDataManager;

    private void Start()
    {
        animalDataManager = GetComponent<AnimalDataManager>();
    }
    public void StartLevel(int levelNumber)
    {
        var dataManager = FindObjectOfType<AnimalDataManager>();
        LevelData levelData = dataManager.LoadLevelData(levelNumber);
        List<string> animalIds = levelData.animalIds;

        string firstAnimalId = animalIds[0];
        GameObject prefab = animalDataManager.LoadPrefabFromId(firstAnimalId);

        if (prefab != null)
        {
            GameObject instance = Instantiate(prefab);
            // Setup animal with additional data...
        }

    }
}

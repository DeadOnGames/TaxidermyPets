using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private AnimalDataGenerator animalDataManager;
    [SerializeField] private List<string> currentLevelAnimalIds;

    private GameManager gameManager;
    private StationManager stationManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
        stationManager = gameManager.stationManager;

        animalDataManager = GetComponent<AnimalDataGenerator>();
    }
    public void StartLevel(int levelNumber)
    {
        LevelData levelData = animalDataManager.LoadLevelData(levelNumber);
        currentLevelAnimalIds = levelData.animalIds;

        //Add animals to queue in station 0
        stationManager.ClearAllQueues();
        foreach(string id in currentLevelAnimalIds)
            stationManager.AddAnimalToQueue(0, id);

        string firstAnimalId = currentLevelAnimalIds[0];
        GameObject prefab = animalDataManager.LoadPrefabFromId(firstAnimalId);

        if (prefab != null)
        {
            
            GameObject instance = Instantiate(prefab);
        }

    }
}

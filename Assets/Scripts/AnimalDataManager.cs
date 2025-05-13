using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AnimalDataManager : MonoBehaviour
{
    private const string ANIMALS_FILE = "animals.json";
    public AnimalData GetAnimalFromId(int animalID)
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, ANIMALS_FILE);

        if (File.Exists(filePath))
        {
            List<AnimalData> allAnimals = new List<AnimalData>();

            string jsonData = File.ReadAllText(filePath);
            var wrapper = JsonUtility.FromJson<AnimalListWrapper>(jsonData);
            allAnimals = wrapper.animals;

            foreach (var animal in allAnimals)
            {
                if (animal.animalId.Equals(animalID)) return animal;
            }
        }
        else
        {
            Debug.LogWarning("Animal not found in database, incorrect id provided: " + animalID);
        }
        return null;
    }
}

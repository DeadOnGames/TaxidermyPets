using System.IO;
using UnityEngine;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class AnimalDataManager : MonoBehaviour
{
    private const string ANIMALS_FILE = "animals.json";
    private const string LEVELS_FOLDER = "Levels";

    private List<AnimalData> allAnimals = new List<AnimalData>();

    private float[] timeSegments = new float[] { 0.25f, 0.5f, 0.75f };

    public int numOfAnimalsToCreate = 20;

    [SerializeField]
    public List<GameObject> animalLibrary = new List<GameObject>();

    [SerializeField]
    public List<AccessoryScriptableObject> accessoriesLibrary = new List<AccessoryScriptableObject>();

    [SerializeField]
    public List<AccessoryScriptableObject> eyesLibrary = new List<AccessoryScriptableObject>();

    void Awake()
    {
        InitializeDataFiles();
        LoadAllAnimals();
    }

    private void InitializeDataFiles()
    {
        string streamingPath = Application.streamingAssetsPath;

        // Create directories if they don't exist
        if (!Directory.Exists(streamingPath))
        {
            Directory.CreateDirectory(streamingPath);
        }

        string levelsPath = Path.Combine(streamingPath, LEVELS_FOLDER);
        if (!Directory.Exists(levelsPath))
        {
            Directory.CreateDirectory(levelsPath);
        }
    }

    public void LoadAllAnimals()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, ANIMALS_FILE);

        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            var wrapper = JsonUtility.FromJson<AnimalListWrapper>(jsonData);
            allAnimals = wrapper.animals;
        }
        else
        {
            Debug.LogWarning("Animals file not found, creating default...");
            GenerateDefaultAnimals();
        }
    }

    private void GenerateDefaultAnimals()
    {
        allAnimals = new List<AnimalData>();

        for (int i = 0; i < numOfAnimalsToCreate; i++)
        {
            int randomAnimalId = Random.Range(0, animalLibrary.Count);
            int randomAccessoryId = Random.Range(0, accessoriesLibrary.Count);
            int randomEyeId = Random.Range(0, accessoriesLibrary.Count);
            int randomTimeSegment1 = Random.Range(0, timeSegments.Length);
            int randomTimeSegment2 = Random.Range(0, timeSegments.Length);
            
            allAnimals.Add(new AnimalData()
            {
                animalId = i + 1,
                animalPrefabPath = $"Prefab/Animals/Animal_{randomAnimalId + 1}",
                washingTime = timeSegments[randomTimeSegment1],
                stuffingTime = timeSegments[randomTimeSegment2],
                eye = new AccessoryData()
                {
                    accessoryId = randomEyeId,
                    accessoryPosition = new Vector3(0, 0, 0)
                },
                accessories = new List<AccessoryData>()
                {
                    new AccessoryData()
                    {
                        accessoryId = randomAccessoryId,
                        accessoryPosition = new Vector3(0,0,0)
                    }
                }
            });
        }

        SaveAnimalsToFile();
    }

    private void SaveAnimalsToFile()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, ANIMALS_FILE);
        var wrapper = new AnimalListWrapper { animals = allAnimals };
        string jsonData = JsonUtility.ToJson(wrapper, true);
        File.WriteAllText(filePath, jsonData);
    }

    public void SaveLevelData(LevelData level)
    {
        string levelsPath = Path.Combine(Application.streamingAssetsPath, LEVELS_FOLDER);
        string fileName = $"level_{level.levelNumber}.json";
        string filePath = Path.Combine(levelsPath, fileName);

        string jsonData = JsonUtility.ToJson(level, true);
        File.WriteAllText(filePath, jsonData);
    }

    public LevelData LoadLevelData(int levelNumber)
    {
        string levelsPath = Path.Combine(Application.streamingAssetsPath, LEVELS_FOLDER);
        string fileName = $"level_{levelNumber}.json";
        string filePath = Path.Combine(levelsPath, fileName);

        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            return JsonUtility.FromJson<LevelData>(jsonData);
        }

        Debug.LogWarning($"Level {levelNumber} file not found at {filePath}");
        return null;
    }

#if UNITY_EDITOR
    [ContextMenu("Generate All Data Files")]
    public void GenerateAllDataFiles()
    {
        // Ensure streaming assets exists
        if (!Directory.Exists(Application.streamingAssetsPath))
        {
            Directory.CreateDirectory(Application.streamingAssetsPath);
        }

        // Generate animals file if missing
        if (!File.Exists(Path.Combine(Application.streamingAssetsPath, ANIMALS_FILE)))
        {
            GenerateDefaultAnimals();
        }

        // Generate 10 levels
        for (int i = 1; i <= 10; i++)
        {
            var level = new LevelData()
            {
                levelNumber = i,
                animalIds = new List<string>()
            };

            // Select 6 unique animals for this level
            for (int j = 0; j < 6; j++)
            {
                int animalIndex = (i * 2 + j) % allAnimals.Count;
                level.animalIds.Add(allAnimals[animalIndex].animalId.ToString());
            }

            SaveLevelData(level);
        }

        AssetDatabase.Refresh();
        Debug.Log("Successfully generated all data files!");
    }
#endif
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int numberOfStations = 5;

    public static GameManager Instance; // A static reference to the GameManager instance
    public int NumberOfStations { get => numberOfStations; private set => numberOfStations = value; }
    public UIScoreDisplay scoreUIElements;

    public LevelManager levelManager = new LevelManager();
    public StationManager stationManager = new StationManager();
    public AnimalDataManager animalDataManager = new AnimalDataManager();
    
    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        levelManager.StartLevel(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int numberOfStations = 3;

    public static GameManager Instance; // A static reference to the GameManager instance
    public int NumberOfStations { get => numberOfStations; private set => numberOfStations = value; }
    public GameObject currentAnimal; //TODO: In future, instantiate this

    
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

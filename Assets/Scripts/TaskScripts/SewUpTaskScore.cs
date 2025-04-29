using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SewUpTaskScore : MonoBehaviour
{
    
    private GameManager gameManager;
    private StationManager stationManager;

    public int numOfSuturePoints { get; private set; }
    public int numOfSuturePointsTriggered { get; private set; }

    //TODO: Calculate the score based on points

    //TODO: Send their score to the animal score keeper on task end

    public void Start()
    {
        gameManager = GameManager.Instance;
        stationManager = gameManager.stationManager;
    }

    public void GetCurrentAnimal()
    {
        //Get current animal on this screen
        stationManager.GetCurrentAnimalAtStation(StationManager.StationNumber.Station3);
    }

    public void CalculatePoints()
    {
        
    }
}

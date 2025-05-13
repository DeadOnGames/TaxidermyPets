using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBuilder : MonoBehaviour
{
    private GameManager gameManager;
    private StationManager stationManager;

    public void Start()
    {
        gameManager = GameManager.Instance;
        stationManager = gameManager.stationManager;
    }

    //Get requirements for next animal in this station
    
    //Link the data to set images on the card
}

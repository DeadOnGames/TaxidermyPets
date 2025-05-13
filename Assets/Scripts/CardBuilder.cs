using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CardBuilder : MonoBehaviour
{
    private GameManager gameManager;
    private StationManager stationManager;
    private AnimalDataManager animalDataManager;

    [SerializeField] private TextMeshProUGUI animalName;
    [SerializeField] private Image animalImage;
    [SerializeField] private Image eyeImage;

    public GameObject cardVisuals;

    public void Start()
    {
        gameManager = GameManager.Instance;
        stationManager = gameManager.stationManager;
        animalDataManager = gameManager.animalDataManager;

        cardVisuals.SetActive(false);
    }

    [ContextMenu("BuildCard")]
    //Get requirements for next animal in this station
    public void BuildCard()
    {
        cardVisuals.SetActive(true);
        var currentAnimalId = stationManager.GetCurrentAnimalAtStation(StationManager.StationNumber.Station0);

        try
        {
            //Get animal data
            int number = Convert.ToInt32(currentAnimalId);
            var currentAnimalData = animalDataManager.GetAnimalFromId(number);
        }
        catch (FormatException)
        {
            Debug.LogError("Invalid cast to int");
        }
    }

    //TODO: Link the data to set images on the card
}

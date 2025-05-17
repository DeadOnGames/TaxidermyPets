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
    private LevelManager levelManager;
    private AnimalDataGenerator animalDataGenerator;

    [SerializeField] private TextMeshProUGUI animalName;
    [SerializeField] private Image washingTimerImage;
    [SerializeField] private Image stuffingTimerImage;
    [SerializeField] private Image animalImage;
    [SerializeField] private Image eyeImage;
    [SerializeField] private List<Image> accessoryImages;

    public GameObject cardVisuals;
    public Sprite oneQuarterTimer;
    public Sprite halfTimer;
    public Sprite threeQuartersTimer;

    public void Start()
    {
        gameManager = GameManager.Instance;
        stationManager = gameManager.stationManager;
        animalDataManager = gameManager.animalDataManager;
        levelManager = gameManager.levelManager;
        animalDataGenerator = levelManager.GetComponent<AnimalDataGenerator>();

        cardVisuals.SetActive(false);
    }

    [ContextMenu("BuildCard")]
    //Get requirements for next animal in this station
    public void BuildCard()
    {
        cardVisuals.SetActive(true);
        var currentAnimalId = stationManager.GetCurrentAnimalAtStation(StationManager.StationNumber.Station0);
        AnimalData currentAnimalData = null;

        try
        {
            //Get animal data and convert to int
            int animalIdInt = Convert.ToInt32(currentAnimalId);
            currentAnimalData = animalDataManager.GetAnimalFromId(animalIdInt);
        }
        catch (FormatException)
        {
            Debug.LogError("Invalid cast animal id to int, cannot build card");
        }

        if (currentAnimalData == null) return;

        //TODO: Link the data to set images on the card
        animalName.text = currentAnimalData.animalName;
        washingTimerImage.sprite = GetTimerImage(currentAnimalData.washingTime);
        stuffingTimerImage.sprite = GetTimerImage(currentAnimalData.stuffingTime);
        //animalImage.sprite = animalDataGenerator.animalLibrary[currentAnimalData.animalId]);

        var eyeLookup = animalDataGenerator.eyesLibrary[currentAnimalData.eye.accessoryId];
        eyeImage.sprite = eyeLookup.accessorySprite;

        for(int i = 0; i < accessoryImages.Count; i++)
        {
            AccessoryScriptableObject accessoryLookup = animalDataGenerator.accessoriesLibrary[currentAnimalData.accessories[i].accessoryId];
            accessoryImages[i].sprite = accessoryLookup.accessorySprite;
        }
        

    }

    private Sprite GetTimerImage(float timerValue)
    {
        switch (timerValue)
        {
            case 0.25f:
                return oneQuarterTimer;
            case 0.5f:
                return halfTimer;
            case 0.75f:
                return threeQuartersTimer;
            default:
                return null;
        }
    }
}

using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextScreenController : MonoBehaviour
{
    private Camera mainCamera;
    private int numberOfStations;
    private GameManager gameManager;

    private List<int> stations = new List<int>();
    private int currentStation;

    public GameObject rightArrow, leftArrow;
    void Start()
    {
        gameManager = GameManager.Instance;
        mainCamera = Camera.main;
        numberOfStations = gameManager.NumberOfStations;

        for (int i = 0; i < numberOfStations; i++)
        {
            stations.Add(i);
        }

        currentStation = 0;
        leftArrow.SetActive(false);
    }

    public void MoveRight()
    {
        mainCamera.transform.Translate(30, 0, 0);
        currentStation = stations[currentStation + 1];
        if (currentStation == stations[stations.Count - 1]) rightArrow.SetActive(false);
        if (currentStation != stations[0]) leftArrow.SetActive(true);

    }

    public void MoveLeft()
    {
        mainCamera.transform.Translate(-30, 0, 0);
        currentStation = stations[currentStation - 1];
        if (currentStation == stations[0]) leftArrow.SetActive(false);
        if (currentStation != stations[stations.Count - 1]) rightArrow.SetActive(true);
    }
}

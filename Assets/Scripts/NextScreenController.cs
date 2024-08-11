using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextScreenController : MonoBehaviour
{
    private Camera mainCamera;
    private int numberOfStations;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        mainCamera = Camera.main;
        numberOfStations = gameManager.NumberOfStations;
    }

    public void MoveRight()
    {
        mainCamera.transform.Translate(15, 0, 0);
    }
    public void MoveLeft()
    {
        mainCamera.transform.Translate(-15, 0, 0);
    }
}

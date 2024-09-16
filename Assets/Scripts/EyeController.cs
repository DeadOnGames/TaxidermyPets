using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeController : MonoBehaviour
{
    public bool isClicked;
    public GameObject dropButton; // Assign the object you want to activate in the inspector

    public GameObject eyeBallPrefab;  
    public Transform spawnPoint;      

    public virtual void OnMouseDown()
    {
        isClicked = true;

        if (dropButton != null)
        {
            dropButton.SetActive(true); // Set the object active on click
        }

        // Instantiate the eyeball at the spawn point
        GameObject newEyeBall = Instantiate(eyeBallPrefab, spawnPoint.position, Quaternion.identity);
    }

}

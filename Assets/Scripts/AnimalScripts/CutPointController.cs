using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CutPointController : MonoBehaviour
{
    public int numOfCutPoints {  get; private set; }
    public int numOfCutPointsTriggered {  get; private set; }

    public List<GameObject> cutPoints = new List<GameObject>();
    public UnityEvent OnCutAllPoints;

    // Start is called before the first frame update
    void Start()
    {
        numOfCutPoints = cutPoints.Count;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Cut point triggered");
    }

    public void AddToCutPoints()
    {
        numOfCutPointsTriggered += 1;
        Debug.Log(numOfCutPointsTriggered + "/" + numOfCutPoints + "cuts made");

        if (numOfCutPointsTriggered.Equals(numOfCutPoints))
        {
            Debug.Log("Animal skin fully cut off");
            HideCutPoints();
            OnCutAllPoints.Invoke();
        } 
    }

    public void HideCutPoints()
    {
        foreach (GameObject cutPoint in cutPoints)
        {
            cutPoint.SetActive(false);
        }
    }
}

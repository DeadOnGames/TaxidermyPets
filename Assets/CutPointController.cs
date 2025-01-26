using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CutPointController : MonoBehaviour
{
    public List<GameObject> cutPoints = new List<GameObject>();
    public int numOfCutPoints;
    public int numOfCutPointsTriggered;

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
            OnCutAllPoints.Invoke();
        } 
    }
}

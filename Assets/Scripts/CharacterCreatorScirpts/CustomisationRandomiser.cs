using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomisationRandomiser : MonoBehaviour
{
    [ContextMenu("Randomise All")]
    public void Randomise()
    {
        //NOTE: Could replace with a more efficient call / caching
        var elements = GetComponentsInChildren<CustomisableElement>();
        foreach (var element in elements)
        {
            element.Randomise();
        }
    }
}

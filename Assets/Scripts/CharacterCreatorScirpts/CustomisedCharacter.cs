using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomisedCharacter : ScriptableObject
{
    private List<CustomisationData> customisationData;
    public void GatherCustomisationData()
    {
        var customisableElements = FindObjectsOfType<CustomisableElement>();
        customisationData = new List<CustomisationData>();
        foreach (var element in customisableElements)
        {
            customisationData.Add(element.GetCustomisationData());
        }
    }

    public void RecreateCharacter()
    {

    }
}

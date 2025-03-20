using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomisableCharacter : MonoBehaviour
{
    [SerializeField]
    private CustomisedCharacter character;

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

    public void StoreCustomisationInfo()
    {
        //NOTE: Could replace with a more efficient call / caching
        var elements = GetComponentsInChildren<CustomisableElement>();
        character.CustomisationData.Clear();

        foreach (var element in elements)
        {
            var currentData = element.GetCustomisationData();
            if (currentData != null) character.CustomisationData.Add(currentData);
        }

        SceneManager.LoadScene("GameScene");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CustomisationUI : MonoBehaviour
{
    private List<UI_CustomisationPicker> pickerList;

    void Start()
    {
        //Could replace this with cached references
        pickerList = GetComponentsInChildren<UI_CustomisationPicker>().ToList();
    }

    public void UpdatePickersState()
    {
        foreach (var picker in pickerList)
        {
            picker.UpdateSpriteId();
            picker.UpdateColourIcon();
        }
    }
}

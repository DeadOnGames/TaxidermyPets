using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessoryButton : MonoBehaviour
{
    public bool isClicked;
    public AccessoryController accessoryController;
    public AccessoryScriptableObject accessoryScriptableObj;

    public virtual void OnMouseDown()
    {
        isClicked = true;
        SetCurrentDropItem();
    }

    public void SetCurrentDropItem()
    {
        if (accessoryController.dropButton != null)
        {
            if (accessoryController.dropButton.activeSelf == false)
            {
                accessoryController.SelectCurrentItem(accessoryScriptableObj);
            }
        }
    }
}

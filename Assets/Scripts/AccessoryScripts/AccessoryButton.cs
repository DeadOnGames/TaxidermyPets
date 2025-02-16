using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessoryButton : MonoBehaviour
{
    public bool isClicked;
    public AccessoryScriptableObject accessoryObject;
    public AccessoryController accessoryController;

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
                //accessoryController.SelectCurrentItem(accessoryObject);
                accessoryController.SelectRandomCurrentItem();
            }
            else
            {
                //TODO: Undo select
            }
        }
    }
}

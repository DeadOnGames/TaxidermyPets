using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_CustomisationPicker : MonoBehaviour
{
    [SerializeField]
    private CustomisableElement customisableElement;

    [SerializeField]
    private Button prevSpriteButton;

    [SerializeField]
    private Button nextSpriteButton;

    [SerializeField]
    private Button prevColourButton;

    [SerializeField]
    private Button nextColourButton;

    [SerializeField]
    private TMP_Text spriteId;

    [SerializeField]
    private Image colourIcon;

    private void Start()
    {
        UpdateSpriteId();

        prevSpriteButton.onClick.AddListener(() =>
        {
            customisableElement.PreviousSprite();
            UpdateSpriteId();
        });

        nextSpriteButton.onClick.AddListener(() =>
        {
            customisableElement.NextSprite();
            UpdateSpriteId();
        });

        if(colourIcon != null)
        {
            UpdateColourIcon();

            prevColourButton.onClick.AddListener(() =>
            {
                customisableElement.PreviousColour();
                UpdateColourIcon();
            });

            nextColourButton.onClick.AddListener(() =>
            {
                customisableElement.NextColour();
                UpdateColourIcon();
            });
        }
        
    }

    public void UpdateSpriteId()
    {
        spriteId.SetText(customisableElement.SpriteIndex.ToString().PadLeft(2, '0'));
    }

    public void UpdateColourIcon()
    {
        colourIcon.color = customisableElement.CurrentColour;
    }
}

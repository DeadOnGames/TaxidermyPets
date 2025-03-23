using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class CustomisableElement : MonoBehaviour
{
    [SerializeField]
    private CustomisationType type;

    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private List<PositionedSprite> spriteOptions;

    [field: SerializeField]
    public int SpriteIndex { get; private set; }

    //[SerializeField] public List<ColourVarSprite> colourOptions;

    [field: SerializeField]
    public int ColourIndex;

    [SerializeField]
    public List<SpriteRenderer> copyColourTo;

    public Color CurrentColour => CheckColourVariationExists() ? spriteOptions[SpriteIndex].ColorVariationSprites[ColourIndex].ColorSwatch : Color.white;

    [ContextMenu("Next sprite")]
    public PositionedSprite NextSprite()
    {
        SpriteIndex = Mathf.Min(SpriteIndex + 1, spriteOptions.Count - 1); //Works like clamp
        UpdateSprite();
        return spriteOptions[SpriteIndex];
    }

    [ContextMenu("Previous sprite")]
    public PositionedSprite PreviousSprite()
    {
        SpriteIndex = Mathf.Max(SpriteIndex - 1, 0);
        UpdateSprite();
        return spriteOptions[SpriteIndex];
    }

    [ContextMenu("Update position modifier")]
    private void UpdateSpritePositionModifier()
    {
        spriteOptions[SpriteIndex].PositionModifier = transform.localPosition;
    }

    public CustomisationData GetCustomisationData()
    {
        return new CustomisationData(type, spriteOptions[SpriteIndex], spriteRenderer.color);
    }

    private void UpdateSprite()
    {
        if (spriteOptions.Count == 0) return;
        SpriteIndex = Mathf.Clamp(SpriteIndex, 0, spriteOptions.Count - 1);
        PositionedSprite positionedSprite = spriteOptions[SpriteIndex];
        spriteRenderer.sprite = positionedSprite.Sprite;

        transform.localPosition = positionedSprite.PositionModifier;
    }

    private void UpdateColour()
    {
        if (!CheckColourVariationExists()) return;
        ColourIndex = Mathf.Clamp(ColourIndex, 0, spriteOptions[SpriteIndex].ColorVariationSprites.Count - 1);
        var newColour = spriteOptions[SpriteIndex].ColorVariationSprites[ColourIndex];
        spriteRenderer.sprite = newColour.Sprite;
        copyColourTo.ForEach(spiteRenderer => spiteRenderer.color = newColour.ColorSwatch);
    }

    [ContextMenu("Next colour")]
    public Color NextColour()
    {
        ColourIndex = Mathf.Min(ColourIndex + 1, spriteOptions[SpriteIndex].ColorVariationSprites.Count - 1);
        UpdateColour();
        return spriteOptions[SpriteIndex].ColorVariationSprites[ColourIndex].ColorSwatch;
    }

    [ContextMenu("Previous colour")]
    public Color PreviousColour()
    {
        ColourIndex = Mathf.Max(ColourIndex - 1, 0);
        UpdateColour();
        return spriteOptions[SpriteIndex].ColorVariationSprites[ColourIndex].ColorSwatch;
    }

    public bool CheckColourVariationExists()
    {
        try
        {
            return (spriteOptions[SpriteIndex].ColorVariationSprites.Count > 0);
        }
        catch (Exception ex)
        {
            Debug.Log("Colour variation not found");
        }
        return false;
    }
    

    [ContextMenu("Randomise")]
    public void Randomise()
    {
        SpriteIndex = UnityEngine.Random.Range(0, spriteOptions.Count - 1);
        ColourIndex = UnityEngine.Random.Range(0, spriteOptions[SpriteIndex].ColorVariationSprites.Count - 1);
        UpdateSprite();
        UpdateColour();
    }
}

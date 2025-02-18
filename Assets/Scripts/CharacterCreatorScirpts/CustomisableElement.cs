using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomisableElement : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private List<PositionedSprite> spriteOptions;

    [field: SerializeField] 
    public int SpriteIndex { get; private set; }

    [SerializeField] public List<Color> colourOptions;

    [field: SerializeField]
    public int ColourIndex;

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

    private void UpdateSprite()
    {
        SpriteIndex = Mathf.Clamp(SpriteIndex, 0, spriteOptions.Count - 1);
        PositionedSprite positionedSprite = spriteOptions[SpriteIndex];
        spriteRenderer.sprite = positionedSprite.Sprite;

        transform.localPosition = positionedSprite.PositionModifier;
    }

    [ContextMenu("Next colour")]
    public Color NextColour()
    {
        ColourIndex = Mathf.Min(ColourIndex + 1, colourOptions.Count - 1);
        UpdateColour();
        return colourOptions[ColourIndex];
    }

    [ContextMenu("Previous colour")]
    public Color PreviousColour()
    {
        ColourIndex = Mathf.Max(ColourIndex - 1, 0);
        UpdateColour();
        return colourOptions[ColourIndex];
    }

    private void UpdateColour()
    {
        spriteRenderer.color = colourOptions[ColourIndex];
    }

    [ContextMenu("Randomise")]
    public void Randomise()
    {
        SpriteIndex = Random.Range(0, spriteOptions.Count - 1);
        ColourIndex = Random.Range(0, colourOptions.Count - 1);
        UpdateSprite();
        UpdateColour();
    }
}

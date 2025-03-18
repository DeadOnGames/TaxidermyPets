using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CustomisationData
{
    [field: SerializeField]
    public CustomisationType Type {  get; private set; }

    [field: SerializeField]
    public PositionedSprite Sprite { get; private set; }

    [field: SerializeField]
    public Color Colour { get; private set; }

    public CustomisationData( CustomisationType type, PositionedSprite sprite, Color colour) 
    { 
        Type = type;
        Sprite = sprite;
        Colour = colour;
    }
}

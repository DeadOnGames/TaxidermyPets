using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PositionedSprite
{
    private int SpriteID;

    [field: SerializeField]
    public Sprite Sprite { get; private set; }

    [field: SerializeField]
    public Vector3 PositionModifier { get; set; }
    [field: SerializeField]
    public List<ColourVarSprite> ColorVariationSprites { get; set; }
}

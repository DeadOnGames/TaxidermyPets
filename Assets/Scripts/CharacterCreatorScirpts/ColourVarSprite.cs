using System;
using UnityEngine;

[Serializable]
public class ColourVarSprite
{
    [field: SerializeField]
    public Sprite Sprite { get; private set; }

    [field: SerializeField]
    public Color ColorSwatch { get; set; }
}

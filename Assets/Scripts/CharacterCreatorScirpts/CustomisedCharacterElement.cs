using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CustomisedCharacterElement : MonoBehaviour
{
    [field: SerializeField]
    public CustomisationType Type {  get; private set; }

    [SerializeField]
    private CustomisedCharacter character;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        var customisation = character.CustomisationData.FirstOrDefault(d => d.Type == Type);

        if(customisation == null) return;
        spriteRenderer.color = customisation.Colour;
        spriteRenderer.sprite = customisation.Sprite.Sprite;
        transform.localPosition = customisation.Sprite.PositionModifier;
    }
}

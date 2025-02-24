using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceCard : MonoBehaviour
{
    private Vector3 originalScale;
    private Vector3 originalPosition;

    private bool isExpanded;
    private float scaleMultiplier = 3;

    public CardController cardController;

    public ReferenceCard()
    {
        isExpanded = false;
    }

    private void Start()
    {
        originalScale = transform.localScale;
        originalPosition = transform.localPosition;
    }

    public void ExpandPhoto()
    {
        if (!isExpanded)
        {
            transform.localScale *= scaleMultiplier;
            transform.localPosition = cardController.GetHighlightedPosition();
            isExpanded = true;
        }
        else
        {
            transform.localScale = originalScale;
            transform.localPosition = originalPosition;
            isExpanded = false;
        }
        
    }
}

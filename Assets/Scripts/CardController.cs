using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    //private List<ReferenceCard> cards = new List<ReferenceCard> { null, null, null, null, null };
    [SerializeField] private Transform highlighedPosition;
    public ReferenceCard highlightedCard = null;

    public void AddCard()
    {

    }

    public void RemoveCard()
    {

    }

    public Vector3 GetHighlightedPosition()
    {
        return highlighedPosition.localPosition;
    }
}

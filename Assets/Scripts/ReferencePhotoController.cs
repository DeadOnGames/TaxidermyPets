using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferencePhotoController : MonoBehaviour
{
    private Vector3 originalScale;
    private Vector3 originalPosition;

    private bool isExpanded;
    public float scaleMultiplier = 2;

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
            transform.localPosition = originalPosition + new Vector3(30,-30,0);
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

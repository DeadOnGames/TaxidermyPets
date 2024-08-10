using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferencePhotoController : MonoBehaviour
{
    private Vector3 originalScale;
    private bool isExpanded;
    public float scaleMultiplier = 2;

    private void Start()
    {
        originalScale = transform.localScale;
    }
    public void ExpandPhoto()
    {
        if (!isExpanded)
        {
            transform.localScale *= scaleMultiplier;
            isExpanded = true;
        }
        else
        {
            transform.localScale = originalScale;
            isExpanded = false;
        }
        
    }
}

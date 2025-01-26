using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutPoint : MonoBehaviour
{
    public bool isCut;
    public CutPointController cutPointsParent;

    // Start is called before the first frame update
    void Start()
    {
        isCut = false;
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //TODO: Check for scalpel 
        if (collision.collider.tag.Equals("Scalpel") && !isCut)
        {
            isCut = true;
            GetComponent<SpriteRenderer>().color = Color.red;
            cutPointsParent.AddToCutPoints();
        }
        
    }
}

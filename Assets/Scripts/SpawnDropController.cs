using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDropController : Draggable
{
    public override void OnMouseDown() 
    {
        Vector3 pos = transform.position;
        Instantiate(this, pos, Quaternion.identity);
    }
}

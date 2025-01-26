using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Progress;

public class ThrowOutTrash : MonoBehaviour
{
    public float duration = 1f;
    public Vector3 moveAway = new Vector3(-50, 0, 0);

    public void OnColliderEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Waste")
        {
            StartCoroutine(ThrowOut(collision.gameObject));
        }
    }

    private IEnumerator ThrowOut(GameObject item)
    {
        //Transport object away
        Vector3 startPosition = item.transform.position;
        float elapsedTime = 0f;

        Camera mainCamera = Camera.main;

        while (elapsedTime < duration)
        {
            Vector3 newPosition = Vector3.Lerp(startPosition, startPosition + new Vector3(10, 0, 0), elapsedTime / duration);

            Vector3 viewportPoint = mainCamera.WorldToViewportPoint(newPosition);
            if (viewportPoint.x < 0 || viewportPoint.x > 1 || viewportPoint.y < 0 || viewportPoint.y > 1)
            {
                item.transform.position += moveAway;
                yield break;
            }

            item.transform.position = newPosition;
            elapsedTime += Time.deltaTime;

            yield return null;
        }
        
        //TODO: Destroy object - could use object pooling in future
        Destroy(gameObject);
    }
}

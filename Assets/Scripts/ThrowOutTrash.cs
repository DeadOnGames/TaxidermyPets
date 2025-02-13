using System.Collections;
using UnityEngine;

public class ThrowOutTrash : MonoBehaviour
{
    public float duration = 1f;
    public Transform destination;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Waste"))
        {
            StartCoroutine(ThrowOut(collision.gameObject));
        }
    }

    private IEnumerator ThrowOut(GameObject item)
    {
        // Transport object to destination
        Vector3 startPosition = item.transform.position;
        Vector3 endPosition = destination.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            // Move the item towards the destination smoothly
            item.transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the object reaches the exact destination
        item.transform.position = endPosition;

        // Optionally disable the renderer after reaching the destination
        item.GetComponent<Renderer>().enabled = false;
    }
}

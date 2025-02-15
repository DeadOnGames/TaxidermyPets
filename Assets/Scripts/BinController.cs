using System.Collections;
using UnityEngine;

public class BinController : MonoBehaviour
{
    public Sprite binOpen;
    public Sprite binClosed;

    private SpriteRenderer binRenderer;

    private void Start()
    {
        binRenderer = GetComponent<SpriteRenderer>();
        binRenderer.sprite = binClosed;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Waste"))
        {
            binRenderer.sprite = binOpen;

            Draggable draggable = collision.collider.GetComponent<Draggable>();
            draggable.dragEndedCallBack = ThrowOut;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        binRenderer.sprite = binClosed;
    }

    private void ThrowOut(Draggable item)
    {
        Destroy(item.gameObject);
        binRenderer.sprite = binClosed;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ThoughtBubble : MonoBehaviour
{
    public UnityEvent onClickThoughtBubble;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void OnMouseDown()
    {
        Debug.Log("Thought bubble clicked");
        onClickThoughtBubble.Invoke();
        Debug.Log("Active after click: " + gameObject.activeSelf);
    }
}

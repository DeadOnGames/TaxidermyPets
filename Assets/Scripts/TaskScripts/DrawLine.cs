using UnityEngine;

public class DrawLine : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private bool canDrawLine;
    private Vector3 initialPosition;
    private Vector3 currentPosition;

    public Material lineMaterial;

    public void SetCanDrawLine(bool canDraw) => canDrawLine = canDraw;

    public void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = lineMaterial;
        lineRenderer.material.color = Color.blue;
        lineRenderer.sortingOrder = 10;
        lineRenderer.enabled = canDrawLine = false;
    }
    
    public void Update()
    {
        //if (!canDrawLine) return;

        if (Input.GetMouseButtonDown(0))
        {
            initialPosition = GetCurrentMousePosition().GetValueOrDefault();
            lineRenderer.SetPosition(0, initialPosition);
            lineRenderer.enabled = true;
        }
        else if (Input.GetMouseButton(0))
        {
            currentPosition = GetCurrentMousePosition().GetValueOrDefault();
            lineRenderer.SetPosition(1, currentPosition);

        }
        else if (Input.GetMouseButtonUp(0))
        {
            lineRenderer.enabled = false;
            var releasePosition = GetCurrentMousePosition().GetValueOrDefault();
            var direction = releasePosition - initialPosition;
            Debug.Log("Process direction " + direction);
        }
    }

    private Vector3? GetCurrentMousePosition()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var plane = new Plane(Vector3.forward, Vector3.zero);

        float rayDistance;
        if (plane.Raycast(ray, out rayDistance))
        {
            return ray.GetPoint(rayDistance);

        }

        return null;
    }

}
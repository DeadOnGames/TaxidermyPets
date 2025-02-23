using UnityEngine;
using UnityEngine.Events;

public class DrawLine : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private int pointCount = 0; 
    private bool isDrawing = false; 
    private Vector3 previewPosition;
    [SerializeField] private int maxLinePoints;

    public Material lineMaterial;
    public UnityEvent onLineComplete;

    public void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = lineMaterial;
        lineRenderer.widthCurve = AnimationCurve.Constant(0, 1, 0.2f);
        lineRenderer.positionCount = 0;
        lineRenderer.sortingOrder = 10;
        lineRenderer.numCornerVertices = 5;
        lineRenderer.enabled = false;
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isDrawing)
            {
                lineRenderer.positionCount = 1;
                lineRenderer.SetPosition(0, GetCurrentMousePosition().GetValueOrDefault());
                lineRenderer.enabled = true;
                isDrawing = true;
                pointCount = 1;
            }
            else
            {
                if (pointCount < maxLinePoints)
                {
                    pointCount++;
                    lineRenderer.positionCount = pointCount;
                    lineRenderer.SetPosition(pointCount - 1, GetCurrentMousePosition().GetValueOrDefault());
                }

                if (pointCount == maxLinePoints)
                {
                    isDrawing = false;
                    onLineComplete.Invoke();
                }
            }
        }

        if (isDrawing && pointCount < maxLinePoints)
        {
            previewPosition = GetCurrentMousePosition().GetValueOrDefault();
            lineRenderer.positionCount = pointCount + 1;
            lineRenderer.SetPosition(pointCount, previewPosition);
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
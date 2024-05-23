using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlurredLineRenderer : MonoBehaviour
{
    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        // Set the width of the line
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;

        // Set the number of points in the line
        lineRenderer.positionCount = 2;

        // Set the positions of the points
        lineRenderer.SetPosition(0, new Vector3(0, 0, 0));
        lineRenderer.SetPosition(1, new Vector3(0, 5, 0));
    }
}

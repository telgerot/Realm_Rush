using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
[SelectionBase]
public class CubeEditor : MonoBehaviour
{
    TextMesh textMesh;
    Vector3 snapPos;
    Waypoint waypoint;
    int gridSize;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
        gridSize = waypoint.GetGridSize();
    }

    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        transform.position = new Vector3(waypoint.GetGridPos().x, 0f, waypoint.GetGridPos().y);
    }

    private void UpdateLabel()
    {
        textMesh = GetComponentInChildren<TextMesh>();
        string labelText = (waypoint.GetGridPos().x / gridSize) + "," + (waypoint.GetGridPos().y / gridSize);
        textMesh.text = labelText;
        gameObject.name = "Waypoint " + labelText;
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{

    public bool isExplored = false;
    public bool isPlaceable = true;
    public Waypoint exploredFrom;

    [SerializeField] Tower towerPrefab;

    const int gridSize = 10;
    Vector2Int gridPos;


    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
        Mathf.RoundToInt(transform.position.x / gridSize),
        Mathf.RoundToInt(transform.position.z / gridSize));
    }

    private void OnMouseOver()
    {
        if (Input.GetButtonDown("Fire1") && isPlaceable == true)
        {
            Instantiate(towerPrefab, transform.position, Quaternion.identity);
            isPlaceable = false;
        }

    }
}

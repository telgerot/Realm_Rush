﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] float movementDelayInSeconds = 2f;

    private void Start()
    {
        PathFinder pathfinder = FindObjectOfType<PathFinder>();
        List<Waypoint> path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    private IEnumerator FollowPath(List<Waypoint> path)
    {
        print("Starting patrol...");
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(movementDelayInSeconds);
        }
        print("Hitting the base");
        GetComponent<EnemyDamage>().DamageBase();
    }
}

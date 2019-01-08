using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path;
    [SerializeField] float movementPerSecond = 1f;

    private void Start()
    {
        StartCoroutine (FollowPath());
    }

    private IEnumerator FollowPath()
    {
        print("Starting patrol...");
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            print("Visiting block: " + waypoint.name);
            yield return new WaitForSeconds(movementPerSecond);
        }
        print("Ending patrol");
    }
}

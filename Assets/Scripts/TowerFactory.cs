using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 3;
    [SerializeField] Tower towerPrefab;
    [SerializeField] Transform towerParentTransform;

    Queue<Tower> towerQueue = new Queue<Tower>();


    public void AddTower(Waypoint baseWaypoint)
    {
        
        if (towerQueue.Count < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower(baseWaypoint);
        }
    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        Tower newTower;
        newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        newTower.transform.parent = towerParentTransform;
        baseWaypoint.isPlaceable = false;
        newTower.myCurrentWaypoint = baseWaypoint;
        towerQueue.Enqueue(newTower);
    }

    private void MoveExistingTower(Waypoint baseWaypoint)
    {
        var movedTower = towerQueue.Dequeue();
        movedTower.myCurrentWaypoint.isPlaceable = true;

        movedTower.transform.position = baseWaypoint.transform.position;
        movedTower.myCurrentWaypoint = baseWaypoint;

        baseWaypoint.isPlaceable = false;
        towerQueue.Enqueue(movedTower);
        
    }
}

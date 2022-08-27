using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    [SerializeField] private Waypoints waypoints;

    [SerializeField] private float movSpeed = 5f;
    [SerializeField] private float distanceThreshold = 0.1f;

    private Transform currentWaypoint;

    private FieldOfView _fov;


    private void Start()
    {
        currentWaypoint = waypoints.getNextWaypoint(currentWaypoint);
        transform.position = currentWaypoint.transform.position;

        currentWaypoint = waypoints.getNextWaypoint(currentWaypoint);

        _fov = this.GetComponent<FieldOfView>();
        
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, movSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold)
        {
            currentWaypoint = waypoints.getNextWaypoint(currentWaypoint);
            transform.LookAt(currentWaypoint);

        }

        canSeePlayer();
        
    }

    private void canSeePlayer()
    {
        
        if (_fov.canSeePlayer)
        {
            transform.LookAt(_fov.playerRef.transform);
            movSpeed = 0f;
        }
        else
            movSpeed = 5f;
    }

    
}

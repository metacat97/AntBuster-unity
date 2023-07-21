using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointerMove : MonoBehaviour
{
    public WayPoints waypoints;
    public float moveSpeed = 5f;
    [SerializeField] private float distanceThreshold = 0.1f;
    //The current waypoint target that the object is moving towards
    private Transform currentWaypoint;

    //The rotation target for the current frame
    private Quaternion rotationGoal;
    // The direction to the next waypoing that the agent needs to rotate towards
    private Vector3 directionToWaypoint;

    
    [Range(0f, 15f)] //How fast the agent will rotate once it reches its waypoint 
    //rotate speed
    [SerializeField] private float rotateSpeed = 4.0f;

    void Start()
    {
        // Set initial position to the first waypoint
        currentWaypoint = waypoints.GetNextWayPoint(currentWaypoint);
        transform.position = currentWaypoint.position;

        //Set the next waypoint target
        currentWaypoint = waypoints.GetNextWayPoint(currentWaypoint);
        transform.LookAt(currentWaypoint);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);
        //Debug.LogFormat("a 와 b 사이의 거리 =>{0} ", Vector3.Distance(transform.position, currentWaypoint.position));
        if (Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold)
        {
            //set the next waypoint target
            currentWaypoint = waypoints.GetNextWayPoint(currentWaypoint);
            //transform.LookAt(currentWaypoint);

        }
        RotateTowardsWaypoint(); 
    }

    //Will slowly rotate the agent towards the current waypoint it is moving towards
    private void RotateTowardsWaypoint()
    {
        directionToWaypoint = (currentWaypoint.position - transform.position).normalized;
        rotationGoal = Quaternion.LookRotation(directionToWaypoint);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationGoal, rotateSpeed * Time.deltaTime);
    }

   









}

using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    [Range(0f, 2f)]
    [SerializeField] private float waypointSize = 1f;

    [Header("Path Settings")]
    // Sets the path to be looped so agent will go from last waypoint to the first or vice versa
    public bool canLoop = true;

    //Sets the agent to move forward or backwards
    public bool isMovingForward = true;
    private void OnDrawGizmos()
    {
        foreach(Transform t in transform)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(t.position, waypointSize);
        }
        Gizmos.color = Color.red;
        for(int i =0; i < transform.childCount - 1; i++)
        {
            Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i + 1).position);

        }
        //If the path is set to loop then drawn a line between the last and first way point
        if (canLoop)
        {
            Gizmos.DrawLine(transform.GetChild(transform.childCount -1).position, transform.GetChild(0).position);
        }
    }


    // Will get the correct next waypoint based on the direction currently travelling
    public Transform GetNextWayPoint(Transform currentWaypoint)
    {
        if (currentWaypoint == null)
        {
            return transform.GetChild(0);    
        }

        // stores the index of the current waypoint
        int currentIndex = currentWaypoint.GetSiblingIndex();

        //Stores the index of the next waypoint to travel towards
        int nextIndex = currentIndex;

        // Agent is moving forward on the path
        if (isMovingForward)
        {
            nextIndex += 1;

            // If the next waypoint index is equal to the count of children/waypoints then it is already at the last waypoint 
            // Check if that path is set to loop and return the first waypoint as the current waypoint, otherwise we subtract 1 
            // from nextIndex which will return the same waypoint that the agent is currently at, which will cause it to stop

            if (nextIndex == transform.childCount)
            {
                if (canLoop)
                {
                    nextIndex = 0;
                }
                else
                {
                    nextIndex -= 1;
                }
            }
        }
        // Agent is moving backwards on the path 
        else
        {
            nextIndex -= 1;

            // If the nextIndex is below 0 then it means that you are already at the first waypoing, check if the path is set
            // to loop and if so return the last waypoint, otherwise we add 1 to the nextIndex which will return the current
            // waypoint that you are already at which will cause the agent to stop since  it is  already there

            if (nextIndex < 0)
            {
                if (canLoop)
                {
                    nextIndex =transform.childCount - 1;
                }
                else
                {
                    nextIndex += 1;
                }
            }
        }

            return transform.GetChild(nextIndex);
    }

        //if (currentIndex < transform.childCount - 1) 
        //{
        //    return transform.GetChild(currentIndex + 1);
        //}
        //else
        //{
        //    if (canLoop)
        //    {
        //        return transform.GetChild(0);
        //    }
        //    else 
        //    {
        //        return transform.GetChild(currentIndex);
        //    }
        //}
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wayPointFollowerScript : MonoBehaviour
{
    //an array of gameObjects (damn!)
    [SerializeField] GameObject[] waypoints;
    //pointer to the first index
    int currentWayPointIndex = 0;

    [SerializeField] float speed = 1f;
    void Update()
    {
        //before moveTowards, we need to know what waypoint we need to move towards next.
        //so we check distance bw currently active waypoint
        //and platform in each frame
        //when close enough, change the waypoint
        if (Vector3.Distance(transform.position, waypoints[currentWayPointIndex].transform.position) < .1f)
        {
            currentWayPointIndex++;
            if(currentWayPointIndex >= waypoints.Length)
            {
                //reset the currentwaypointindex when we reach the last waypoint in the array
                currentWayPointIndex = 0;
            }
        }
        //calculates the new postition between two game objects
        //takes in position of the platform
        //position of the waypoint we want to move towards
        //how far we want to move (Time.deltaTime used to move one game unit/second, essentially framerate independent)
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWayPointIndex].transform.position, speed * Time.deltaTime);


    }
}

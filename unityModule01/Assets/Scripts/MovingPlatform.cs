using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed;
    private int currWaypoint = 0;
    private bool goingPositive = true;
    // Start is called before the first frame update
    void Start()
    {
        currWaypoint = 0;
        goingPositive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (waypoints.Length > 0)
        {
            if (goingPositive == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, waypoints[currWaypoint].position, speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, waypoints[currWaypoint].position) < 0.01f)
                {
                    currWaypoint++;
                }
                if (currWaypoint >= waypoints.Length)
                {
                    goingPositive = false;
                    currWaypoint = waypoints.Length - 1;
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, waypoints[currWaypoint].position, speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, waypoints[currWaypoint].position) < 0.01f) 
                {
                    currWaypoint--;
                }
                if (currWaypoint < 0)
                {
                    goingPositive = true;
                    currWaypoint = 0;
                }
            }
        }
    }

    void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            player.transform.parent = this.transform;
        }
    }
    void OnTriggerExit(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            player.transform.parent = null;
        }
    }
}

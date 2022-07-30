using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horizontal_Waypoint : MonoBehaviour
{
    public GameObject[] waypoints;

    int current = 0;
    float rotSpeed;
    public float speed;
    float WPradius = 0.1f;
    void Update()
    {
        if(Vector3.Distance(waypoints[current].transform.position, transform.position) < WPradius) //dönüm noktaları
        {
            current = Random.Range(0,waypoints.Length);
            if(current >= waypoints.Length)
            {
                current = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
    }
}
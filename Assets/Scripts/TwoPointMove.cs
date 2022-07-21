using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoPointMove : MonoBehaviour
{    
    public Transform PointA;
    public Transform PointB;
    public float speed = 1.19f;
    Vector3 pointA;
    Vector3 pointB;
    
    void Start()
    {
        //pointA = new Vector3(0, 0, 0);
        //pointB = new Vector3(5, 0, 0);

        pointA = PointA.transform.position;
        pointB = PointB.transform.position;
    }

    void Update()
    {
        //PingPong between 0 and 1
        float time = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector3.Lerp(pointA, pointB, time);
    }
}

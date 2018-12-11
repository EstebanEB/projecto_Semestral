using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class movBase : MonoBehaviour
{

    public int hP;
    public int speedMovement;

    public Rigidbody rbd;
    public GameObject target;

    Vector3 initialPosition;

    public Transform[] pathPoints;  //array of positions
    public int CurrentPath = 0;  //the index of the Path
    public float ReachDistance = 5.0f; //waypoints colisionZone


    protected virtual void Start()
    {
        rbd = GetComponent<Rigidbody>();
        initialPosition = transform.position;
    }


    void Update()
    {

    }

    public void walk()
    {
        Vector3 dir = pathPoints[CurrentPath].position - transform.position;  // the direction
        Vector3 dirNorm = dir.normalized; // normalizing direction

        transform.Translate(dirNorm * (speedMovement * Time.fixedDeltaTime)); //Moves the transform in the direction of the translation

        if (dir.magnitude <= ReachDistance)      // magnitude returns the length of the vector dir, and compare with the reach distance
        {
            CurrentPath++;


            if (CurrentPath >= pathPoints.Length)    // start again to follow the wayPoints
            {
                CurrentPath = 0;
            }
        }


    }

    void onDrawGizmos()
    {
        if (pathPoints.Length == 0)
            return;

        foreach (Transform pathPoint in pathPoints) // for every PathPoint draw a sphere
        {
            if (pathPoint)
            {
                Gizmos.color = Color.cyan;
                Gizmos.DrawSphere(pathPoint.position, ReachDistance);
            }
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{

    public Vector3[] localWaypoints;
    public float speed;
    public float waitTime = .4f;
    [Range(0, 2)]
    public float easeAmount;

    int fromWaypointIndex;
    float percentBetweenWaypoint;
    float nextMoveTime;

    private Vector3[] globalWaypoints;

    Transform parentPosition;

    void Start()
    {
        parentPosition = GetComponentInParent<Transform>();
        globalWaypoints = new Vector3[localWaypoints.Length];
        for (int i = 0; i < globalWaypoints.Length; i++)
        {
            globalWaypoints[i] = localWaypoints[i] + parentPosition.position;
        }
    }

   
    void Update()
    {
        transform.Translate(CalculateObstacleMovement());
    }

    float Ease(float x)
    {
        float a = easeAmount + 1;
        return Mathf.Pow(x, a) / (Mathf.Pow(x, a) + Mathf.Pow(1 - x, a));
    }

    Vector3 CalculateObstacleMovement()
    {
        if (Time.time < nextMoveTime)
        {
            return Vector3.zero;
        }

        int toWaypointIndex = fromWaypointIndex + 1;
        float distanceBetweenWaypoints = Vector3.Distance(globalWaypoints[fromWaypointIndex], globalWaypoints[toWaypointIndex]);
        percentBetweenWaypoint += Time.deltaTime * speed / distanceBetweenWaypoints;
        percentBetweenWaypoint = Mathf.Clamp01(percentBetweenWaypoint);
        float easedPercentBetweenWaypoint = Ease(percentBetweenWaypoint);

        Vector3 newPosition = Vector3.Lerp(globalWaypoints[fromWaypointIndex], globalWaypoints[toWaypointIndex], easedPercentBetweenWaypoint);

        if (percentBetweenWaypoint >= 1)
        {
            percentBetweenWaypoint = 0;
            fromWaypointIndex++;

            if (fromWaypointIndex >= globalWaypoints.Length - 1)
            {
                fromWaypointIndex = 0;
                System.Array.Reverse(globalWaypoints);
            }

            nextMoveTime = Time.time + waitTime;
        }

        return newPosition - parentPosition.position;
    }

    private void OnDrawGizmos()
    {
        parentPosition = GetComponentInParent<Transform>();
        if (localWaypoints != null)
        {
            Gizmos.color = Color.blue;
            float size = .3f;

            for (int i = 0; i < localWaypoints.Length; i++)
            {
                Vector3 globalWaypointsPos = (Application.isPlaying) ? globalWaypoints[i] : localWaypoints[i] + parentPosition.position;
                Gizmos.DrawLine(globalWaypointsPos - Vector3.up * size, globalWaypointsPos + Vector3.up * size);
                Gizmos.DrawLine(globalWaypointsPos - Vector3.left * size, globalWaypointsPos + Vector3.left * size);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("qualcosa e entrato");
        CharMovement player =  collision.GetComponent<CharMovement>();
        player.healt--;
    }
}
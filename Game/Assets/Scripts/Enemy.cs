using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private static Vector2[] routePoints = new Vector2[]
    {
        new Vector2(-5, 3),
        new Vector2(4, 2),
        new Vector2(-4, 1),
        new Vector2(2, 0),
        new Vector2(-2, -1),
        new Vector2(1, -2),
        new Vector2(-1, -3),
        new Vector2(0, -4),
    };

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float rotationSpeed;

    private int nextPointIndex;
    private bool isInitialized;

    // Start is called before the first frame update
    void Start()
    {
        nextPointIndex = 0;
        isInitialized = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isInitialized || nextPointIndex >= routePoints.Length)
		{
            return;
		}

        Move();
    }

    private void Move()
	{
        Vector2 point = routePoints[nextPointIndex];
        float distanceX = point.x - transform.position.x;
        float distanceY = point.y - transform.position.y;

        if (Mathf.Abs(distanceX) < moveSpeed * Time.deltaTime && Mathf.Abs(distanceY) < moveSpeed * Time.deltaTime)
        {
            nextPointIndex++;
            return;
        }

        float directionX = distanceX / Mathf.Abs(distanceX) * Mathf.Min(Mathf.Abs(distanceX) / Mathf.Abs(distanceY), 1);
        float directionY = distanceY / Mathf.Abs(distanceY) * Mathf.Min(Mathf.Abs(distanceY) / Mathf.Abs(distanceX), 1);

        Vector2 movementDirection = new Vector2(directionX * moveSpeed * Time.deltaTime, directionY * moveSpeed * Time.deltaTime);
        transform.Translate(movementDirection, Space.World);

        Quaternion rotationTo = Quaternion.LookRotation(Vector3.forward, movementDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationTo, rotationSpeed * Time.deltaTime);
    }
}
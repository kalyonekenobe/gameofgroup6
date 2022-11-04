using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    private class Point2D
    {
        public float x;
        public float y;

        public Point2D(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    private static Point2D[] routePoints = new Point2D[]
  {
        new Point2D(-5, 3),
        new Point2D(4, 2),
        new Point2D(-4, 1),
        new Point2D(2, 0),
        new Point2D(-2, -1),
        new Point2D(1, -2),
        new Point2D(-1, -3),
        new Point2D(0, -4),
    };

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
        if (isInitialized)
        {
            if (nextPointIndex < routePoints.Length)
            {
                Point2D point = routePoints[nextPointIndex];
                if (Mathf.Abs(transform.position.x - point.x) < moveSpeed / 2 && Mathf.Abs(transform.position.y - point.y) < moveSpeed / 2)
                {
                    nextPointIndex++;
                    Debug.Log(point);
                }
                float dx = (point.x - transform.position.x) / Mathf.Abs(point.x - transform.position.x) * Mathf.Min(Mathf.Abs(point.x - transform.position.x) / Mathf.Abs(point.y - transform.position.y), 1);
                float dy = (point.y - transform.position.y) / Mathf.Abs(point.y - transform.position.y) * Mathf.Min(Mathf.Abs(point.y - transform.position.y) / Mathf.Abs(point.x - transform.position.x), 1);
                float stepX = dx * moveSpeed * Time.deltaTime;
                float stepY = dy * moveSpeed * Time.deltaTime;
                Vector3 movementDirection = new Vector3(stepX, stepY, 0);
                Quaternion rotationTo = Quaternion.LookRotation(movementDirection, Vector3.forward);
                transform.Translate(movementDirection, Space.World);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationTo, 360 * Time.deltaTime);
            }
        }
    }
}
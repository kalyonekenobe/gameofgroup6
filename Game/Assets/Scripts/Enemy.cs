using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
 
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private int lifes = 4;

    private int nextPointIndex;
    private bool isInitialized;
    private Vector2[] routePoints;


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

    public void Hit()
    {
        lifes--;
        //Debug.Log($"lifes {lifes}");
        switch (lifes)
        {

            case 3:
                {
                    //renderer.color = new Color(255f, 204f, 0f, 0.7f);
                    GetComponent<SpriteRenderer>().color = new Color32(200, 200, 0, 225);
                    break;
                }
            case 2:
                {
                    GetComponent<SpriteRenderer>().color = new Color32(255, 153, 0, 225);
                    //renderer.color = new Color(1f, 102f, 0f, 0.7f);
                    break;
                }
            case 1:
                {
                    GetComponent<SpriteRenderer>().color = new Color32(204, 51, 0, 225);
                    //renderer.color = new Color(204f, 51f, 0f, 0.7f);
                    break;
                }
            case 0:
                {
                    Destroy(gameObject);
                    break;
                }
        }

    }

    public void SetRoutePoints(Vector2 [] routePoints)
    {
        this.routePoints = (Vector2[]) routePoints.Clone();
    }

    private void Move()
	{
        

        Vector2 point = routePoints[nextPointIndex];
        float distanceX = point.x - transform.position.x;
        float distanceY = point.y - transform.position.y;

        if ((Vector2) gameObject.transform.position == routePoints[routePoints.Length - 1])
            Destroy(gameObject);

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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemySO enemyType;

    private int lives;
    private int nextPointIndex;
    private bool isInitialized;
    //
    private Vector2[] routePoints;


    // Start is called before the first frame update
    void Start()
    {
        lives = enemyType.lives;
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

    public void Hit(int hit)
    {
        lives-=hit;
        
        //Debug.Log($"lifes {lifes}");
        if(lives <= 0)
        {
            Destroy(gameObject);
        }
        else if(lives <= enemyType.lives / 4)
        {
            GetComponent<SpriteRenderer>().color = new Color32(204, 51, 0, 225);
        }
        else if(lives <= enemyType.lives / 2)
        {
            GetComponent<SpriteRenderer>().color = new Color32(255, 153, 0, 225);
        }
        else if(lives <= 3 * enemyType.lives / 4)
        {
            GetComponent<SpriteRenderer>().color = new Color32(200, 200, 0, 225);
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

        if ((Vector2) gameObject.transform.position == routePoints[routePoints.Length - 2])
            Destroy(gameObject);

            if (Mathf.Abs(distanceX) < enemyType.moveSpeed * Time.deltaTime && Mathf.Abs(distanceY) < enemyType.moveSpeed * Time.deltaTime)
        {
            nextPointIndex++;
            return;
        }

        float directionX = distanceX / Mathf.Abs(distanceX) * Mathf.Min(Mathf.Abs(distanceX) / Mathf.Abs(distanceY), 1);
        float directionY = distanceY / Mathf.Abs(distanceY) * Mathf.Min(Mathf.Abs(distanceY) / Mathf.Abs(distanceX), 1);

        Vector2 movementDirection = new Vector2(directionX * enemyType.moveSpeed * Time.deltaTime, directionY * enemyType.moveSpeed * Time.deltaTime);
        transform.Translate(movementDirection, Space.World);

        Quaternion rotationTo = Quaternion.LookRotation(Vector3.forward, movementDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationTo, enemyType.rotationSpeed * Time.deltaTime);
    }
}
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public EnemySO enemyType;

    [SerializeField]
    private Animator animator;
    private PlayerData player;
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private GameObject healthCanvas;

    private int lives;
    private int nextPointIndex;
    private bool isInitialized;
    //
    private Vector2[] routePoints;
    private bool rotated;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>().playerData;
        lives = enemyType.lives;
        slider.maxValue = lives;
        slider.value = lives;
        nextPointIndex = 0;
        isInitialized = true;
        if (animator != null)
            animator.SetBool("IsAlive", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isInitialized || nextPointIndex >= routePoints.Length)
        {
            return;
        }

        if (lives > 0)
        {
            Move();
        }

    }

    public bool IsAlive()
    {
        return lives > 0;
    }

    public void Hit(int hit)
    {
        if (lives == enemyType.lives)
        {
            healthCanvas.SetActive(true);
        }
        lives -= hit;

        slider.value = lives;

        if (animator != null)
            animator.SetTrigger("Hit");

        //Debug.Log($"lifes {lifes}");
        if (lives <= 0)
        {
            if (animator != null)
                animator.SetBool("IsAlive", false);
            animator.SetTrigger("Die");
        }
        else if (lives <= enemyType.lives / 4)
        {
            GetComponent<SpriteRenderer>().color = new Color32(204, 51, 0, 225);
        }
        else if (lives <= enemyType.lives / 2)
        {
            GetComponent<SpriteRenderer>().color = new Color32(255, 153, 0, 225);
        }
        else if (lives <= 3 * enemyType.lives / 4)
        {
            GetComponent<SpriteRenderer>().color = new Color32(200, 200, 0, 225);
        }

    }

    public void SetRoutePoints(Vector2[] routePoints)
    {
        this.routePoints = (Vector2[])routePoints.Clone();
    }

    private void Move()
    {

        Vector2 point = routePoints[nextPointIndex];
        float distanceX = point.x - transform.position.x;
        float distanceY = point.y - transform.position.y;
        float absDistanceX = Mathf.Abs(distanceX);
        float absDistanceY = Mathf.Abs(distanceY);

        if (nextPointIndex >= routePoints.Length - 1)
        {
            Destroy(gameObject);
            player.RemoveHealth(enemyType.damage);
            Debug.Log("Enemy esacaped");
        }


        if (absDistanceX < enemyType.moveSpeed * Time.deltaTime && absDistanceY < enemyType.moveSpeed * Time.deltaTime)
        {
            nextPointIndex++;
            return;
        }

        float directionX = (absDistanceX < 1e-20 ? 1 : (distanceX / absDistanceX)) * Mathf.Min(absDistanceX / (absDistanceY < 1e-20 ? absDistanceX : absDistanceY), 1);
        float directionY = (absDistanceY < 1e-20 ? 1 : (distanceY / absDistanceY)) * Mathf.Min(absDistanceY / (absDistanceX < 1e-20 ? absDistanceY : absDistanceX), 1);

        Vector2 movementDirection = new Vector2(directionX * enemyType.moveSpeed * Time.deltaTime, directionY * enemyType.moveSpeed * Time.deltaTime);

        if (!rotated && distanceX < 0) { transform.Rotate(0, 180, 0); rotated = true; }
        else if (rotated && distanceX >= 0) { rotated = false; transform.Rotate(0, 180, 0); }


        transform.Translate(movementDirection, Space.World);

    }
}
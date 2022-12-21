using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField]
    private GameObject bow;
    private GameObject currBow;
    private bool isInitialized;
    public TowerTypeSO towerType;
    private float currentCoolDown;
    private bool CanShoot() => currentCoolDown <= 0;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize();
    }

    public void Initialize()
    {
        currBow = Instantiate(bow);//створюємо лук для башні
        currBow.transform.position = transform.position;
        currBow.transform.localScale += new Vector3(0.65f, 0.67f, 1.1f);
        currBow.transform.localPosition += new Vector3(0.04f, 0.45f, -1f);
        currBow.transform.parent = transform;
        currBow.transform.rotation = bow.transform.rotation;
        currentCoolDown = towerType.coolDown;
        isInitialized = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isInitialized)
        {
            return;
        }
        Transform nearestEnemy = FindNearestEnemy();
        currBow.GetComponent<Bow>().target = nearestEnemy;
        //шукаємо найближчого енемі і туди направляємо лук,а якщо енемі в зоні украження то стріляємо

        if (CanShoot())
        {
            if (nearestEnemy is not null && Vector2.Distance(transform.position, nearestEnemy.transform.position) <= towerType.range)
            {
                Shoot(nearestEnemy);
            }
        }

        if (currentCoolDown > 0)
        {
            currentCoolDown -= Time.deltaTime;
        }
    }

    private Transform FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float distanceToNearestEnemy = Mathf.Infinity;
        Transform nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);

            if (distance < distanceToNearestEnemy)
            {
                nearestEnemy = enemy.transform;
                distanceToNearestEnemy = distance;
            }
        }
        return nearestEnemy;
    }

    private void Shoot(Transform enemy)//цей метод можна перенсти в клас Bow,але я не чіпав,щоб при мерджі було менше проблем
    {
        GetComponent<AudioSource>().Play();
        // Debug.Log($"Tower Enemy {enemy.position}");
        GameObject projectileClone = Instantiate(towerType.projectile);
        projectileClone.transform.position = currBow.transform.position;
        //projectileClone.transform.parent = currBow.transform;
       // projectileClone.transform.rotation = currBow.transform.rotation;
        projectileClone.GetComponent<Projectile>().SetPower(towerType.hit);
        projectileClone.GetComponent<Projectile>().SetEnemy(enemy);
        projectileClone.GetComponent<Projectile>().Initialize();

        currentCoolDown = towerType.coolDown;
    }

    public int GetCost()
    {
        return towerType.cost;
    }
}

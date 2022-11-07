using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField]
    private float coolDown;
    [SerializeField]
    private float range;
    [SerializeField]
    private int cost;
    [SerializeField]
    private GameObject projectile;
    
    private float currentCoolDown;
    private bool isInitialized;

    private bool CanShoot() => currentCoolDown <= 0;
    
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        currentCoolDown = 0;
        isInitialized = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isInitialized)
		{
            return;
		}

        if (CanShoot())
		{
            Transform nearestEnemy = FindNearestEnemy();

            if (nearestEnemy is not null)
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
            
            if (distance < distanceToNearestEnemy && distance <= range)
            {
                nearestEnemy = enemy.transform;
                distanceToNearestEnemy = distance;
            }
        }
        return nearestEnemy;
    }

    private void Shoot(Transform enemy)
    {
       // Debug.Log($"Tower Enemy {enemy.position}");
        GameObject projectileClone = Instantiate(projectile);
        projectileClone.transform.position = transform.position;
        projectileClone.GetComponent<Projectile>().SetEnemy(enemy);
        projectileClone.GetComponent<Projectile>().Initialize();
        currentCoolDown = coolDown;
    }

    public int GetCost()
    {
        return cost;
    }
}

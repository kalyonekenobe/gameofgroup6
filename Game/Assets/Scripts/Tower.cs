using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{// Start is called before the first frame update

    [SerializeField]
    private float coolDown, range;
    private float currCoolDown=0;
    [SerializeField]
    private GameObject projectile;
    private bool canShoot()
    {
        if (currCoolDown<=0)
            return true;
        return false;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot())
            findEnemy();
        if (currCoolDown > 0)
            currCoolDown -= Time.deltaTime;

    }
    void findEnemy()
    {
        Transform nearestEnemy = null;
        float nearestEnemyDistance = Mathf.Infinity;
        //can be changed
        foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            float currDistance =Vector2.Distance(transform.position,enemy.transform.position);
            if(currDistance < nearestEnemyDistance&&currDistance<=range)
            {
                nearestEnemy = enemy.transform;
                nearestEnemyDistance = currDistance;
            }

        }
        if(nearestEnemy != null)
            shoot(nearestEnemy);
    }
    void shoot(Transform enemy)
    {
        currCoolDown = coolDown;
        GameObject obj = Instantiate(projectile);
        obj.transform.position = transform.position;
        obj.GetComponent<Projectile>().setEnemy(enemy);

        

    }
}

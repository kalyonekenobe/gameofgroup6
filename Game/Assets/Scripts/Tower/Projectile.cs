using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;

    private Transform target;
    private bool isInitialized;
    private int power = 1;
    [SerializeField]
    private Animator animator;

    public void SetEnemy(Transform enemy) => target = enemy;

  

    public void Initialize()
    {
        isInitialized = true;

    }

    public void SetPower(int power)
    {
        this.power = power;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isInitialized)
        {
            return;
        }

        Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (collision.gameObject.GetComponent<Enemy>().IsAlive())
            {
                collision.gameObject.GetComponent<Enemy>().Hit(power);

            }
            Destroy(gameObject);



        }
    }

    private void Move()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        var dir = target.position - transform.position;
        var angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, -angle);

     
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);

    }
}


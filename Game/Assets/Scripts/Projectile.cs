using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;

    private Transform target;
    private bool isInitialized;
    private int power = 1;

	public void SetEnemy(Transform enemy) => target = enemy;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

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
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().Hit(power);
            //Debug.Log($"Projectile hit the target with position {target.position}");
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
        //Debug.Log($"Projectile Enemy {target.position}");
        Vector2 path = target.position - transform.position;
        transform.Translate(path.normalized * Time.deltaTime * speed);
    }
}

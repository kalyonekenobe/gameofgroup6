using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform target;
    [SerializeField]
    private float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    //name can be changed
    private void fly()
    {
        if (target != null)
        {
            if (Mathf.Abs(Vector2.Distance( transform.position,target.position)) < 0.8f)
            {
               Destroy(gameObject);
            }
            else
            {
               Vector2 path = target.position - transform.position;
            transform.Translate(path.normalized * Time.deltaTime * speed);
            }
                
        }
        else
        {
            Destroy(gameObject);
        }
    }
    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Destroy(gameObject);

    //}

    // Update is called once per frame
    void Update()
    {
        fly();
    }
    public void setEnemy(Transform enemy)
    {
        target=enemy;
    }
}

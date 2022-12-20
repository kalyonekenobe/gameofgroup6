using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bow : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
  
        if (target != null)
        {
            var dir = target.position - transform.position;
            var angle = Mathf.Atan2(dir.x, dir.y)*Mathf.Rad2Deg;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -angle), Time.deltaTime*9.0f );
        //повертаємо лук
        }

        
    }
}

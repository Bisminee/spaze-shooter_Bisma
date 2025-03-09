using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : HealthEntity
{
    public float speed = 2f;

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }
}


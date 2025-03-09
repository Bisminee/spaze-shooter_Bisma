using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    private Rigidbody2D rb;
    public float speed = 400;
    public float lifeTime = 3;
    private float time = 0;
    private Vector2 relativeDirection;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();

        Rotate rotateComponent = player.GetComponent<Rotate>();
        if (rotateComponent != null)
        {
            relativeDirection = rotateComponent.RelativeDirection;
        }
        else
        {
            relativeDirection = Vector2.up; // Default arah ke atas jika Rotate tidak ditemukan
        }
    }


    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > lifeTime)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = relativeDirection.normalized * speed * Time.fixedDeltaTime;
    }

}

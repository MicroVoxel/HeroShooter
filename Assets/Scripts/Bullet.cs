using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed;

    private void Start()
    {
        speed = 8f;
    }

    private void Update()
    {
        Vector2 pos = transform.position;

        pos = new Vector2(pos.x, pos.y + speed * Time.deltaTime);

        transform.position = pos;

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        if(transform.position.y > max.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }

}


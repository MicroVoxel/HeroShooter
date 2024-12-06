using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    GameObject scoreUI;

    public GameObject Explode;

    private void Start()
    {
        scoreUI = GameObject.FindGameObjectWithTag("Score");
    }

    private void Update()
    {
        Move(transform.position);
    }

    public override void Move(Vector2 pos)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        pos = new Vector2(pos.x, pos.y - speed * Time.deltaTime);
        transform.position = pos;

        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == "Player") || (collision.tag == "PlayerBullet"))
        {
            PlayExplode();
            scoreUI.GetComponent<GameScore>().Score += 100;
            Destroy(gameObject);
        }
    }

    void PlayExplode()
    {
        GameObject explosion = (GameObject)Instantiate(Explode);
        explosion.transform.position = transform.position;
    }
}


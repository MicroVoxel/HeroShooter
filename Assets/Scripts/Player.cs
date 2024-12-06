using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public GameObject gameManager;
    public GameObject playerBullet;
    public GameObject bulletPos1;
    public GameObject bulletPos2;
    public GameObject Explode;

    const int MaxHp = 5;

    public int HP 
    { 
        get { return health; } 
        private set { } 
    }

    public void Init()
    {
        health = MaxHp;

        transform.position = new Vector2 (0, 0);

        gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            AudioSource audioData = gameObject.GetComponent<AudioSource>();
            audioData.Play();

            GameObject bullet01 = (GameObject)Instantiate(playerBullet);
            bullet01.transform.position = bulletPos1.transform.position;

            GameObject bullet02 = (GameObject)Instantiate(playerBullet);
            bullet02.transform.position = bulletPos2.transform.position;
        }

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(x, y).normalized;

        Move(direction);
    }

    public override void Move(Vector2 direction)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        max.x = max.x - 0.225f;
        min.x = min.x + 0.225f;

        max.y = max.y - 0.285f;
        min.y = min.y + 0.285f;

        Vector2 pos = transform.position;

        pos += direction * speed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x,min.x,max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((collision.tag == "Enemy") || (collision.tag == "EnemyBullet"))
        {
            TakeDamage();
        }
    }

    public override void TakeDamage()
    {
        PlayExplode();
        health--;
        if (health <= 0)
        {
            gameManager.GetComponent<GameManager>().SetGMState(GameManager.GameManagerState.GameOver);

            gameObject.SetActive(false);
        }
    }

    void PlayExplode()
    {
        GameObject explosion = (GameObject)Instantiate(Explode);
        explosion.transform.position = transform.position;
    }

}
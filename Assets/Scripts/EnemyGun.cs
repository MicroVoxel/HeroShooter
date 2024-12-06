using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public GameObject EnemyBullet;

    void Start()
    {
        Invoke("FireEnemyBullet", 1f);
    }

    void FireEnemyBullet()
    {
        GameObject player = GameObject.Find("Player");

        if (player != null) 
        {
            GameObject bullet = (GameObject)Instantiate(EnemyBullet);

            bullet.transform.position = transform.position;

            Vector2 direction = player.transform.position - bullet.transform.position;

            bullet.GetComponent<EnemyBullet>().SetDirection(direction);
        }
    }
}

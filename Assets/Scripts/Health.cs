using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject[] HP;
    public Player player;

    void Update()
    {
        for (int i = 0; i < HP.Length; i++)
        {
            HP[i].SetActive(i < player.HP);
        }
    }
}


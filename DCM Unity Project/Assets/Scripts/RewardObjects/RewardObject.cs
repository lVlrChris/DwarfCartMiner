﻿using UnityEngine;
using System.Collections;

public class RewardObject : MonoBehaviour
{
    public int health;
    public int goldReward;
    public int crystalReward;

    private Player playerScript;

    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }


    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            switch (other.gameObject.name)
            {
                case "ShotgunShells":
                    TakeDamage(other.GetComponent<ShotgunShell>().damage);

                    break;
                case "RifleBullet":
                    TakeDamage(other.GetComponent<RifleBullet>().damage);

                    break;
            }
        }
    }


    private void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            playerScript.GainGold(goldReward);
            playerScript.GainCrystal(crystalReward);
        }
    }
}

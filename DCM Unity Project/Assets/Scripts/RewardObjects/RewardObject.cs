using UnityEngine;
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
                case "ShotgunShell":
                    TakeDamage(other.GetComponent<ShotgunShell>().damage);

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
            playerScript.gold += goldReward;
            playerScript.crystal += crystalReward;
        }
    }
}

using UnityEngine;
using System.Collections;

public class DwarfEnemy : Enemy {



	void Start ()
    {
        base.Start();
	}
	

	void Update () 
    {
        base.Update();
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
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
            }
        }
    }

    private void TakeDamage(int damage)
    {
        curHealth -= damage;
        if (curHealth <= 0)
        {
            Destroy(gameObject);
            playerScript.GainGold(goldReward);
            playerScript.GainCrystal(crystalReward);
        }
    }
}

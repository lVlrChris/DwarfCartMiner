using UnityEngine;
using System.Collections;

public class DwarfEnemy : Enemy {


	void Start () {
	
	}
	

	void Update () 
    {
        base.Update();
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
        curHealth -= damage;
        if (curHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}

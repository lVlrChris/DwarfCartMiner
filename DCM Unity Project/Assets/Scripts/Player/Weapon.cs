using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MyEnums;

public class Weapon : MonoBehaviour {

    private RaycastHit hit;
    private float rayDistance = 10000.0f;


    public WeaponType selectedWeapon;

    public List<GameObject> allProjectiles;
    public GameObject projectileSpawn;
    private GameObject projectileToFire;

    public float fireTimer;

    public float    shotGunCooldown,
                    swordCooldown,
                    rifleCooldown;

    public AudioClip    shotGunSound,
                        rifleSound,
                        swordSound;

    private AudioSource audioSource;

    void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	

	void Update () {
        GetInput();

        if (fireTimer >= 0)
        {
            fireTimer -= Time.deltaTime;
        }
	}

    private void GetInput()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            LookAtMouse();
            FireWeapon();
        }
    }
    
    private void FireWeapon()
    {
        switch (selectedWeapon)
        {
            case WeaponType.Shotgun:
                projectileToFire = allProjectiles[0];
                if (fireTimer <= 0)
                {
                    GameObject GO = Instantiate(projectileToFire, projectileSpawn.transform.position, projectileSpawn.transform.rotation) as GameObject;
                    GO.name = "ShotgunShells";
                    fireTimer = shotGunCooldown;
                    audioSource.PlayOneShot(shotGunSound);
                }
                break;
            case WeaponType.Rifle:
                projectileToFire = allProjectiles[1];
                if (fireTimer <= 0)
                {
                    GameObject GO = Instantiate(projectileToFire, projectileSpawn.transform.position, projectileSpawn.transform.rotation) as GameObject;
                    GO.name = "RifleBullet";
                    fireTimer = rifleCooldown;
                    audioSource.PlayOneShot(rifleSound);
                }
                break;
            case WeaponType.Sword:
                projectileToFire = allProjectiles[2];
                break;
        }
    }

    private void LookAtMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            transform.LookAt(hit.point);
            transform.rotation = new Quaternion(0.0f, transform.rotation.y, 0.0f, transform.rotation.w);
        }
    }
}

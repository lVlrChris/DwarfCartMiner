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


    void Start () {
        
	}
	

	void Update () {
        GetInput();
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
                Instantiate(projectileToFire, projectileSpawn.transform.position, projectileSpawn.transform.rotation);
                break;
            case WeaponType.MachineGun:
                projectileToFire = allProjectiles[1];
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

using UnityEngine;
using System.Collections;
using MyEnums;

public class GameController : MonoBehaviour {

    private Player player;
    private Weapon weapon;
    public Canvas endScreen;


    private GameObject[] storageCarts;
    private GameObject[] enemies;

	void Start () 
    {
        weapon = GameObject.FindGameObjectWithTag("Gunner").GetComponent<Weapon>();
        Time.timeScale = 1;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}
	

	void Update () 
    {
	
	}

    public void EndGame()
    {
        Time.timeScale = 0;
        endScreen.gameObject.SetActive(true);
    }

    public void ReloadLevel()
    {
        PlayerPrefs.SetInt("Gold", player.gold);
        Application.LoadLevel("Game");
    }

    public void LoadMenu()
    {
        PlayerPrefs.SetInt("Gold", player.gold);
        Application.LoadLevel("Menu");
    }

    public void SwitchWeapon(string weap)
    {
        switch (weap)
        {
            case "ShotGun":
                weapon.selectedWeapon = WeaponType.Shotgun;
                break;
            case "Rifle":
                weapon.selectedWeapon = WeaponType.Rifle;
                break;
        } 
    }

}

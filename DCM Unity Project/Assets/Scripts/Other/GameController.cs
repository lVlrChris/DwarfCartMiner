using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using MyEnums;

public class GameController : MonoBehaviour {

    private Player player;
    private Weapon weapon;
    public Canvas endScreen;

    public bool gamePlaying;


    private GameObject[] storageCarts;
    private GameObject[] enemies;

	void Start () 
    {
        gamePlaying = true;
        weapon = GameObject.FindGameObjectWithTag("Weapon").GetComponent<Weapon>();
        Time.timeScale = 1;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}
	

	void Update () 
    {
        DebugInput();
	}



    public void EndGame()
    {
        gamePlaying = false;
        Time.timeScale = 0;
        endScreen.gameObject.SetActive(true);
    }

    public void ReloadLevel()
    {
        PlayerPrefs.SetInt("Gold", player.gold);
        SceneManager.LoadScene("Game");
    }

    public void LoadMenu()
    {
        PlayerPrefs.SetInt("Gold", player.gold);
        SceneManager.LoadScene("Menu");
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

    private void DebugInput()
    {
        if(Input.GetKeyDown(KeyCode.KeypadMultiply))
        {
            player.gold -= (player.gold - 1);
            PlayerPrefs.SetInt("Gold", player.gold);
        }
    }
}

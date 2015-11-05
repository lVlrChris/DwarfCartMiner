using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    private Player player;
    public Canvas endScreen;


    private GameObject[] storageCarts;
    private GameObject[] enemies;

	void Start () 
    {
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

}

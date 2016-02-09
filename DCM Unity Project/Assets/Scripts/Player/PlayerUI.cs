using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {

    public Text goldText, crystalText;
    public Image selectedGun;

    private Player player;
    private Weapon weapon;



    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        weapon = GameObject.FindGameObjectWithTag("Weapon").GetComponent<Weapon>();
	}
	

	void Update () {
        UpdateCurrencies();
	}

    private void UpdateCurrencies()
    {
        goldText.text = "Gold: " + player.gold;
        crystalText.text = "Crystal: " + player.crystal;
    }

    private void ShowSelectedGun()
    {
        
    }
}

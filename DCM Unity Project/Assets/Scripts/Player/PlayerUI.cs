using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using MyEnums;

public class PlayerUI : MonoBehaviour {

    public Text goldText, crystalText;
    public Image selectedWeapon;

    private Player player;
    private Weapon weapon;

    public Sprite   shotgunSprite,
                    rifleSprite;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        weapon = GameObject.FindGameObjectWithTag("Weapon").GetComponent<Weapon>();
	}
	

	void Update () {
        UpdateCurrencies();
        ShowSelectedGun();
	}

    private void UpdateCurrencies()
    {
        goldText.text = "Gold: " + player.gold;
        crystalText.text = "Crystal: " + player.crystal;
    }

    private void ShowSelectedGun()
    {
        switch (weapon.selectedWeapon)
        {
            case WeaponType.Shotgun:
                selectedWeapon.sprite = shotgunSprite;
                break;

            case WeaponType.Rifle:
                selectedWeapon.sprite = rifleSprite;
                break;
;

        }
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    private CartController cartController;
    public List<Vector3> previousPos;
    int i;
    public int levelLengthInSeconds;

    public int gold;
    public int crystal;

    public Text goldText, crystalText;

    public GameObject[] storageCarts;

	void Start ()
    {
        MoveOnPathLine("LevelPathLine", iTween.EaseType.linear, levelLengthInSeconds);
        cartController = GetComponent<CartController>();
        gold = PlayerPrefs.GetInt("Gold");
        if (gold <= 0)
        {
            GetAllCartValues();
        }
	}
	

	void Update () 
    {
        previousPos.Add(transform.position);
        UIUpdate();
	}

    private void UIUpdate()
    {
        goldText.text = "Gold: " + gold;
        crystalText.text = "Crystal: " + crystal;
    }

    private void MoveOnPathLine(string pathLineName, iTween.EaseType easetype, float time)
    {
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath(pathLineName), "easetype", easetype, "time", time, "orientToPath", true, "lookahead", 0.08f));
    }

    public void GainGold(int goldAmount)
    {
        gold += goldAmount;
        storageCarts = GameObject.FindGameObjectsWithTag("StorageCart");
        GameObject storageCart = storageCarts[0];
        foreach (GameObject cart in storageCarts)
        {
            if (cart.GetComponent<StorageCart>().ID >= 0)
            {
                storageCart = cart;
            }
            if (cart.GetComponent<StorageCart>().ID > storageCart.GetComponent<StorageCart>().ID)
            {
                storageCart = cart;
            }
        }

       StorageCart cartScript = storageCart.GetComponent<StorageCart>();

       cartScript.curGold += goldAmount;
       if (cartScript.curGold >= cartScript.maxGold)
       {
           cartController.goldForNewCart = (cartScript.curGold - cartScript.maxGold);
           cartScript.curGold = cartScript.maxGold;
           cartController.SpawnCart();
       }
    }

    public void GainCrystal(int crystalAmount)
    {

    }

    private void GetAllCartValues()
    {
        storageCarts = GameObject.FindGameObjectsWithTag("StorageCart");
        foreach (GameObject cart in storageCarts)
        {
            gold += cart.GetComponent<StorageCart>().curGold;
        }
    }
}

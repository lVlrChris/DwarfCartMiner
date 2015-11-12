using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CartController : MonoBehaviour {

    public GameObject storageCart;
    private GameObject latestCart;
    private GameObject[] allCarts;

    public int goldForNewCart;

	void Start () 
    {
	
	}
	

	void Update () {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SpawnCart();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            DestroyCart();
        }
	}

    public void SpawnStartCarts(int gold)
    {
        allCarts = GameObject.FindGameObjectsWithTag("StorageCart");
        foreach (GameObject cart in allCarts)
        {
            if (cart.GetComponent<StorageCart>().ID == 0)
            {
                if (gold >= 50)
                {
                    cart.GetComponent<StorageCart>().curGold = 50;
                    gold -= 50;
                }
                else 
                {
                    cart.GetComponent<StorageCart>().curGold = gold;
                }
            }
        }

        float amountOfCarts = gold / 50;
        Debug.Log(amountOfCarts);
        for (int i = 0; i < amountOfCarts + 1; i++)
        {
            if (gold >= 50)
            {
                goldForNewCart = 50;
            }
            else if(gold < 50 && gold >= 0)
            {
                goldForNewCart = gold;
            }
            gold -= 50;
            SpawnCart();
        }
    }

    public void SpawnCart()
    {
        FindLatestCart();
        GameObject GO = Instantiate(storageCart, new Vector3(0, 0, 0), storageCart.transform.rotation) as GameObject;
        GO.GetComponent<StorageCart>().target = latestCart;
        GO.GetComponent<StorageCart>().ID = latestCart.GetComponent<StorageCart>().ID + 1;
        GO.name = "StorageCart";
        GO.GetComponent<StorageCart>().curGold = goldForNewCart;
    }

    public void DestroyCart()
    {
        FindLatestCart();
        if (latestCart.GetComponent<StorageCart>().ID > 0)
        {
            Destroy(latestCart.gameObject);
        }
    }

    private void FindLatestCart()
    {
        allCarts = GameObject.FindGameObjectsWithTag("StorageCart");
        foreach (GameObject cart in allCarts)
        {
            if (latestCart != null)
            {
                if (cart.GetComponent<StorageCart>().ID > latestCart.GetComponent<StorageCart>().ID)
                {
                    latestCart = cart;
                }
            }
            else
            {
                latestCart = cart;
            }
        }
    }

    
}

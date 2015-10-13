using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CartController : MonoBehaviour {

    public GameObject storageCart;
    private GameObject latestCart;
    private GameObject[] allCarts;

	void Start () {
	
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

    public void SpawnCart()
    {
        FindLatestCart();
        GameObject GO = Instantiate(storageCart, new Vector3(0, 0, 0), storageCart.transform.rotation) as GameObject;
        GO.GetComponent<StorageCart>().target = latestCart;
        GO.GetComponent<StorageCart>().ID = latestCart.GetComponent<StorageCart>().ID + 1;
        GO.name = "StorageCart";
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

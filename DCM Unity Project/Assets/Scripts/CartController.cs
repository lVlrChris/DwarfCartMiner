using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CartController : MonoBehaviour {

    public GameObject mineCart;
    private GameObject latestCart;
    private GameObject[] allCarts;

	void Start () {
	
	}
	

	void Update () {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SpawnCart();
        }
	}

    public void SpawnCart()
    {
        FindLatestCart();
        GameObject GO = Instantiate(mineCart, new Vector3(0, 0, 0), mineCart.transform.rotation) as GameObject;
        GO.GetComponent<Minecart>().target = latestCart;
        GO.GetComponent<Minecart>().ID = latestCart.GetComponent<Minecart>().ID + 1;
        GO.name = "Minecart";
    }

    private void FindLatestCart()
    {
        allCarts = GameObject.FindGameObjectsWithTag("Minecart");
        foreach (GameObject cart in allCarts)
        {
            if (latestCart != null)
            {
                if (cart.GetComponent<Minecart>().ID > latestCart.GetComponent<Minecart>().ID)
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

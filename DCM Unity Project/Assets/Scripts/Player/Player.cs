using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    private CartController cartController;
    public List<Vector3> previousPos;

    public int curHealth;
    public int maxHealth;

    public int levelLengthInSeconds;

    public int gold;
    public int crystal;

    NavMeshAgent agent;

    public GameObject[] storageCarts;

    private GameController gameController;

    public GameObject exit;


    void Awake()
    {
    }

	void Start ()
    {
        exit = GameObject.FindGameObjectWithTag("Exit");
        agent = GetComponent<NavMeshAgent>();
        gameController = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameController>();
        //MoveOnPathLine("LevelPathLine", iTween.EaseType.linear, levelLengthInSeconds);
        cartController = GetComponent<CartController>();
        gold = PlayerPrefs.GetInt("Gold");
        if (gold <= 0)
        {
            GetAllCartValues();
        }
        else
        {
            cartController.SpawnStartCarts(gold);
        }

	}
	

	void Update () 
    {
        if (gameController.gamePlaying && Vector3.Distance(transform.position, exit.transform.position) < 1)
        {
            agent.Stop();
            EndGame();
        }
        else
        {

            agent.SetDestination(exit.transform.position);
        }
        previousPos.Add(transform.position);
	}

    public void TakeDamage(int damage)
    {
        curHealth -= damage;
        if (curHealth <= 0)
        {
            gameController.ReloadLevel();
        }
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

    private void MoveOnPathLine(string pathLineName, iTween.EaseType easetype, float time)
    {
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath(pathLineName), "easetype", easetype, "time", time, "orientToPath", true, "lookahead", 0.08f, "oncomplete", "EndGame"));
    }

    private void GetAllCartValues()
    {
        storageCarts = GameObject.FindGameObjectsWithTag("StorageCart");
        foreach (GameObject cart in storageCarts)
        {
            if (cart.GetComponent<StorageCart>().ID == 0)
            {
                cart.GetComponent<StorageCart>().curGold = 25;
                gold = 25;
            }
        }
    }


    private void EndGame()
    {
        gameController.EndGame();
    } 
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public int curHealth;
    public int maxHealth;

    public Text healthUI;

    [HideInInspector]public GameObject player;
    [HideInInspector]public Player playerScript;

    public int goldReward;
    public int crystalReward;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<Player>();
    }

    public void Update()
    {
        UIUpdate();
        transform.LookAt(player.transform.position);
    }

    private void UIUpdate()
    {
        healthUI.text = curHealth + " / " + maxHealth;
    }
}

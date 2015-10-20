using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public int curHealth;
    public int maxHealth;

    public Text healthUI;

    public void Update()
    {
        UIUpdate();
    }

    private void UIUpdate()
    {
        healthUI.text = curHealth + " / " + maxHealth;
    }
}

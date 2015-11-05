using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {


	void Start ()
    {
	
	}
	

	void Update () 
    {
	
	}

    public void StartGame()
    {
        Application.LoadLevel("Game");
    }
}

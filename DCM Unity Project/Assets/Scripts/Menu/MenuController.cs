using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {


	void Start ()
    {
	
	}
	

	void Update () 
    {
	
	}

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
        
    }
}

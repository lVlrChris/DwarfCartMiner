using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StorageCart : MonoBehaviour {

    public GameObject target;
    public int ID;
    public List<Vector3> previousPos;

    private int frameCounter;
    private int framesBehind = 40;

	void Start () {
        if(target.name == "Player")
        {
            frameCounter = target.GetComponent<Player>().previousPos.Count - framesBehind;
        }
        else if (target.name == "StorageCart")
        {
            frameCounter = target.GetComponent<StorageCart>().previousPos.Count - framesBehind;
        }
	}
	

	void Update () {
        frameCounter++;

        previousPos.Add(transform.position);

        if(target.name == "Player" && target.GetComponent<Player>().previousPos.Count >= framesBehind)
        {
            transform.position = target.GetComponent<Player>().previousPos[frameCounter];
            
        }
        else if (target.name == "StorageCart" && target.GetComponent<StorageCart>().previousPos.Count >= framesBehind)
        {
            transform.position = target.GetComponent<StorageCart>().previousPos[frameCounter];
        }
        transform.LookAt(target.transform);
	}
}

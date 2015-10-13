using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StorageCart : MonoBehaviour {

    public GameObject target;

    public int ID;
    public List<Vector3> previousPos;
    int i;

	void Start () {
        if(target.name == "Player")
        {
            i = target.GetComponent<Player>().previousPos.Count - 25;
        }
        else if (target.name == "StorageCart")
        {
            i = target.GetComponent<StorageCart>().previousPos.Count - 25;
        }
	}
	

	void Update () {
        i++;

        previousPos.Add(transform.position);

        if(target.name == "Player" && target.GetComponent<Player>().previousPos.Count >= 10)
        {
            transform.position = target.GetComponent<Player>().previousPos[i];
            
        }
        else if (target.name == "StorageCart" && target.GetComponent<StorageCart>().previousPos.Count >= 10)
        {
            transform.position = target.GetComponent<StorageCart>().previousPos[i];
        }
        transform.LookAt(target.transform);
	}
}

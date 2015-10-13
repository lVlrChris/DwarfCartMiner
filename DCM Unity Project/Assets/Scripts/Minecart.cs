using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Minecart : MonoBehaviour {

    public GameObject target;

    public int ID;
    public List<Vector3> previousPos;
    int i;

	void Start () {
        if(target.name == "Player")
        {
            i = target.GetComponent<Player>().previousPos.Count - 25;
        }
        else if (target.name == "Minecart")
        {
            i = target.GetComponent<Minecart>().previousPos.Count - 25;
        }
	}
	

	void Update () {
        i++;

        previousPos.Add(transform.position);

        if(target.name == "Player" && target.GetComponent<Player>().previousPos.Count >= 10)
        {
            transform.position = target.GetComponent<Player>().previousPos[i];
            
        }
        else if (target.name == "Minecart" && target.GetComponent<Minecart>().previousPos.Count >= 10)
        {
            transform.position = target.GetComponent<Minecart>().previousPos[i];
        }
        transform.LookAt(target.transform);
	}
}

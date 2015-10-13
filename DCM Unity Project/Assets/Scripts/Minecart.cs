using UnityEngine;
using System.Collections;

public class Minecart : MonoBehaviour {

    public GameObject target;

    public Vector3[] previousPos = new Vector3[10];
    int i;

	void Start () {
	    
	}
	

	void Update () {
        previousPos[i] = transform.position;
        i++;
        if (i >= 10)
        {
            i = 0;
        }

        if(target.name == "Player")
        {
            transform.position = target.GetComponent<Player>().previousPos[9];
        }
        else if (target.name == "Minecart")
        {
            transform.position = target.GetComponent<Minecart>().previousPos[9];
        }
        transform.LookAt(target.transform);
	}
}

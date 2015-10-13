using UnityEngine;
using System.Collections;

public class CameraFocus : MonoBehaviour {

    private GameObject target;

	void Start () {
        target = GameObject.Find("Player");
	}
	

	void Update () {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y + 50, target.transform.position.z);
	}
}

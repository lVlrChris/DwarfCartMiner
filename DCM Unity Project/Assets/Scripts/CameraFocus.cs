using UnityEngine;
using System.Collections;

public class CameraFocus : MonoBehaviour {

    private GameObject target;
    public float cameraHeight;

	void Start () {
        target = GameObject.Find("Player");
	}
	

	void Update () {
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.transform.position.x, target.transform.position.y + cameraHeight, target.transform.position.z), 10 * Time.deltaTime);
	}
}

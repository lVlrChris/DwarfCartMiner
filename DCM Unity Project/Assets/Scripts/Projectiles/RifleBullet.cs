using UnityEngine;
using System.Collections;

public class RifleBullet : MonoBehaviour {

    public int damage;
    public float speed;

	void Start () 
    {
        Destroy(gameObject, 5);
	}
	

	void Update () 
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}

}

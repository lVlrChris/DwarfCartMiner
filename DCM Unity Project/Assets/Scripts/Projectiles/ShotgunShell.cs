using UnityEngine;
using System.Collections;

public class ShotgunShell : MonoBehaviour {

    public float speed;
    public int damage;

	void Start () {
        Destroy(transform.parent.gameObject, 10);
	}
	

	void Update () {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}

    void OnCollisionEnter(Collision collider)
    {
        Destroy(gameObject);
    }
}

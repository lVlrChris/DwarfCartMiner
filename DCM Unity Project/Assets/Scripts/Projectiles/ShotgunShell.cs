using UnityEngine;
using System.Collections;

public class ShotgunShell : MonoBehaviour {

    public float speed;
    public int damage;

    private GameObject rightShell, leftShell;
    private BoxCollider collider;

	void Start ()
    {
        rightShell = transform.FindChild("ShotgunShellRight").gameObject;
        leftShell = transform.FindChild("ShotgunShellLeft").gameObject;
        collider = GetComponent<BoxCollider>();
	}
	

	void Update () {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        collider.size = new Vector3(collider.size.x + 1f, collider.size.y, collider.size.z);
        if (speed > 20)
        {
            speed -= 3f;
            rightShell.transform.Translate(5 * Time.deltaTime, 0, 0, Space.Self);
            leftShell.transform.Translate(-5 * Time.deltaTime, 0, 0, Space.Self);
        }
        else if (speed <= 30 && speed > 0)
        {
            speed -= 1f;
            rightShell.transform.Translate(1 * Time.deltaTime, 0, 0, Space.Self);
            leftShell.transform.Translate(-1 * Time.deltaTime, 0, 0, Space.Self);
        }
        else if (speed <= 0)
        {
            Destroy(gameObject);
        }

	}

}

using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

    private RaycastHit hit;
    private float rayDistance = 10000.0f;


    void Start () {
	
	}
	

	void Update () {
        GetInput();
	}

    private void GetInput()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            LookAtMouse();
        }
    }

    private void LookAtMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            transform.LookAt(hit.point);
            transform.rotation = new Quaternion(0.0f, transform.rotation.y, 0.0f, transform.rotation.w);
        }
    }
}

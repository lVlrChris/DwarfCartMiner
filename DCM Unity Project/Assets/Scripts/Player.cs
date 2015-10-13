using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public Vector3[] previousPos = new Vector3[10];
    int i;

	// Use this for initialization
	void Start () {
        MoveOnPathLine("LevelPathLine", iTween.EaseType.linear, 15);
	}
	
	// Update is called once per frame
	void Update () {
        previousPos[i] = transform.position;
        i++;
        if (i >= 10)
        {
            i = 0;
        }
	}

    private void MoveOnPathLine(string pathLineName, iTween.EaseType easetype, float time)
    {
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath(pathLineName), "easetype", easetype, "time", time, "orientToPath", true, "lookahead", 0.01f));
    }
}

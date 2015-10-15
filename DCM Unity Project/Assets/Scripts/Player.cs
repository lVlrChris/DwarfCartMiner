using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

    public List<Vector3> previousPos;
    int i;


	void Start () {
        MoveOnPathLine("LevelPathLine", iTween.EaseType.linear, 15);
	}
	

	void Update () {
        previousPos.Add(transform.position);


	}

    private void MoveOnPathLine(string pathLineName, iTween.EaseType easetype, float time)
    {
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath(pathLineName), "easetype", easetype, "time", time, "orientToPath", true, "lookahead", 0.01f));
    }
}

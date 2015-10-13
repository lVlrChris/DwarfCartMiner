using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
        MoveOnPathLine("LevelPathLine", iTween.EaseType.linear, 15);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void MoveOnPathLine(string pathLineName, iTween.EaseType easetype, float time)
    {
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath(pathLineName), "easetype", easetype, "time", time, "orientToPath", true, "lookahead", 0.01f));
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public List<Vector3> previousPos;
    int i;
    public int levelLengthInSeconds;

    public int gold;
    public int crystal;

    public Text goldText, crystalText;


	void Start () {
        MoveOnPathLine("LevelPathLine", iTween.EaseType.linear, levelLengthInSeconds);

	}
	

	void Update () {
        previousPos.Add(transform.position);
        UIUpdate();
	}

    private void UIUpdate()
    {
        goldText.text = "Gold: " + gold;
        crystalText.text = "Crystal: " + crystal;
    }

    private void MoveOnPathLine(string pathLineName, iTween.EaseType easetype, float time)
    {
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath(pathLineName), "easetype", easetype, "time", time, "orientToPath", true, "lookahead", 0.08f));
    }
}

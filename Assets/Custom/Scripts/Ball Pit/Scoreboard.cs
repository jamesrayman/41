using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour {

	Text text;
	public static float time = 0;

	void Start () {
		text = gameObject.GetComponent<Text> ();
	}

	void Update () {
		time += Time.deltaTime;
		int secondsLeft = Mathf.Max(0, (int)(60 - time));
		if (time < 60.5)
			text.text = "Time:" + string.Format("{0,2}:", secondsLeft / 60) + (secondsLeft % 60).ToString().PadLeft(2, '0') + "\nScore:" + string.Format("{0,4}", Score.score);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {
	Text text;
	public static int prev = 0, high;

	void Start () {
		text = GetComponent<Text> ();
		high = PlayerPrefs.GetInt ("HS");
	}

	void Update () {
		text.text = string.Format("High Score: {0}{3}\nPrevious Game Score: {1}\n<size=140>Score: {2}</size>", 
			high, prev, Game.score, (high == 124000 ? " (Dev High Score)" : ""));

		if (Game.score > high) {
			high = Game.score;
			PlayerPrefs.SetInt ("HS", high);
		}
	}
}

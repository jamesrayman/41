using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

	public static int score;

	public static void addScore (int s) {
		score += s;
		if (score < 0)
			score = 0;
	}
}

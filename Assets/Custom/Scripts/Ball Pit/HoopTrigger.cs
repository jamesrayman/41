using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopTrigger : MonoBehaviour {

	public Pulse pulse;
	public int score;
	public bool resetHoop;

	public void OnTriggerExit (Collider other) {
		if (other.gameObject.tag == "Ball" && other.transform.position.y < transform.position.y) {
			pulse.pulse ();
			if (resetHoop) {
				Score.score = 0;
				Scoreboard.time = 0;
			} else {
				Score.addScore (score);
			}
		}
	}
}

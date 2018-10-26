using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gs = GameSettings;

// Responsible for spawning blocks

public class Spawner : MonoBehaviour {
	public static Spawner main;

	static RationalCurve spawnGapCurve;
	static bool spawning = true;
	static float gap;

	float timeUntilNext = 0;

	void Start () {
		main = this;
		spawnGapCurve = new RationalCurve (gs.initialSpawnGap, gs.initialSpawnGapSlope, gs.spawnGapLimit);
		Reset();

		// Debug
		// useful for curve callibration
		/* for (int i = 0; i < 100; i++) {
			Debug.Log(string.Format("f({0}) = {1}", i, spawnGapCurve.Evaluate(i)));
		} */
	}

	void Update () {
		if (spawning && (timeUntilNext <= 0 || BlockManager.CountActive() == 0)) {
			timeUntilNext = gap;

			Spawn ();
			// Debug
			//Spawn();
		}
		if (spawning) {
			timeUntilNext -= Time.deltaTime;
		}
	}

	public Block Spawn () {
		GameObject g = Instantiate(Utility.Array.RandElement(gs.spawnlist));
		g.transform.localScale = Vector3.one * gs.blockSize;
		g.transform.SetPositionAndRotation (Vector3.up * gs.spawnHeight, g.transform.rotation);
		return g.GetComponent<Block>();
	}

	public static void Reset () {
		spawnGapCurve.Reset ();
		gap = spawnGapCurve.Evaluate();
	}
	public static void SpeedUp () {
		spawnGapCurve.Advance ();
		gap = spawnGapCurve.Evaluate();

		// useful for curve calibration
		// Debug.Log (gap);
	}
	public static float GetSpawnGap () {
		return gap;
	}

	public static void Activate () {
		spawning = true;
	}
	public static void Deactivate () {
		spawning = false;
	}
}

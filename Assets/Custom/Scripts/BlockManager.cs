using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Responsible for management of all active blocks

public static class BlockManager {
	// A list of all blocks which are manipulatable by the player
	static List<Block> active = new List<Block>();

	public static void AddActive (Block block) {
		active.Add (block);
	}
	public static void RemoveActive (Block block) {
		active.Remove (block);
	}
	public static int CountActive () {
		return active.Count;
	}

	public static void Clear () {
		for (int i = active.Count - 1; i > -1; i--) {
			Object.Destroy (active[i].gameObject);
		}
		active.Clear ();
	}

	public static Block AutoGrabBlock () {
		Block block = null;
		float height = float.PositiveInfinity;

		foreach (Block candidate in active) {
			if (candidate.IsAutoGrabbable () && candidate.transform.position.y < height) {
				block = candidate;
				height = candidate.transform.position.y;
			}
		}

		if (block == null) {
			return Spawner.main.Spawn ();
		}
		return block;
	}
	public static float LowestUngrabbedHeight () {
		float height = GameSettings.spawnHeight;

		foreach (Block candidate in active) {
			if (candidate.IsAutoGrabbable () && candidate.transform.position.y < height) {
				height = candidate.transform.position.y;
			}
		}

		return height;
	}

	public static float BlockFallingSpeed (float height) {
		float areaHeight = (GameSettings.areaHeight+5) * GameSettings.blockSize;

		if (height < areaHeight)
			return GameSettings.blockFallingSpeed;

		//Debug.Log (GameSettings.blockFallingSpeed * Mathf.Exp(height/8));
		return GameSettings.blockFallingSpeed * Mathf.Exp((height - areaHeight) * GameSettings.blockFallingGradient);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Responsible for management of all active blocks

public static class BlockManager {
	// A list of all blocks which are manipulatable by the player
	static List<Block> active = new List<Block>();
	static List<Block> planting = new List<Block> ();

	public static void AddActive (Block block) {
		active.Add (block);
	}
	public static void RemoveActive (Block block) {
		active.Remove (block);
	}
	public static int CountActive () {
		return active.Count;
	}

	public static void Plant (Block block) {
		
	}
	public static void Unplant (Block block) {

	}

	public static void Clear () {
		for (int i = active.Count - 1; i > -1; i--) {
			Object.Destroy (active[i].gameObject);
		}
		active.Clear ();
	}

	public static void UnplantAll () {
		foreach (Block block in active) {
			block.Unlay();
		}
	}
}

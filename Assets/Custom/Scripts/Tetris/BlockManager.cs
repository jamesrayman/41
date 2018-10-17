using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Responsible for management of all active blocks

public static class BlockManager {
	// A list of all blocks which are manipulatable by the player
	static List<Block> active = new List<Block>();

	public static void Add (Block block) {
		active.Add (block);
	}
	public static void Remove (Block block) {
		active.Remove (block);
	}
	public static int Count () {
		return active.Count;
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

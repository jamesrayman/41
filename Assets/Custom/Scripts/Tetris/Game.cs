using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gs = GameSettings;

// Responsible for the central mechanics of the game

public static class Game {
	public static int score = 0;

	public static void EndGame () {
		ScoreDisplay.prev = score;
		Game.Reset();
		Spawner.Deactivate();
	}
	public static void StartGame () {
		Spawner.Activate();
	}

	public static void Reset () {
		Spawner.Reset ();
		BlockArea.Reset ();
		BlockManager.Clear();
		score = 0;
	}

	public static void AddScore (int layerClears) {
		if (layerClears < 1)
			return;

		// 1000 for 1 layer
		// 4x for every extra layer
		score += (Mathf.RoundToInt(Mathf.Pow(4, layerClears-1))) * 1000;
	}
}
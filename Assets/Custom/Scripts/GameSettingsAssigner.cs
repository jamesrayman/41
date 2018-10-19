using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// assigns all editor-public game settings

public class GameSettingsAssigner : MonoBehaviour {

	// Block Area

	public float blockSize;
	public float borderWidth;
	public float borderHeight;
	public float floorHeight;
	public int areaSize;
	public int areaHeight;


	// Blocks

	public float blockFallingSpeed;
	public float plantTime;


	// Spawner

	public float spawnHeight;
	public GameObject[] spawnlist;

	// Difficulty Curve

	public float initialSpawnGap;
	public float initialSpawnGapSlope;
	public float spawnGapLimit;

	public void Awake () {
		Assign ();
	}

	public void Assign () {
		// Block Area
		GameSettings.blockSize = blockSize;
		GameSettings.borderWidth = borderWidth;
		GameSettings.borderHeight = borderHeight;
		GameSettings.floorHeight = floorHeight;
		GameSettings.areaSize = areaSize;
		GameSettings.areaHeight = areaHeight;
		GameSettings.fullAreaHeight = areaHeight+20;

		// Blocks
		GameSettings.blockFallingSpeed = blockFallingSpeed;
		GameSettings.plantTime = plantTime;

		// Spawner
		GameSettings.spawnHeight = spawnHeight;
		GameSettings.spawnlist = spawnlist;

		// Difficulty curve
		GameSettings.initialSpawnGap = initialSpawnGap;
		GameSettings.initialSpawnGapSlope = initialSpawnGapSlope;
		GameSettings.spawnGapLimit = spawnGapLimit;
	}
}

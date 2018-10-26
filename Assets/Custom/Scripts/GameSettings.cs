using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// contains all editor-public game settings

public static class GameSettings {
	// Note that all settings are assigned by GameSettingsAssigner

	// Block Area
	public static float blockSize;
	public static float borderWidth;
	public static float borderHeight;
	public static float floorHeight;
	public static int areaSize;
	public static int areaHeight;
	public static int fullAreaHeight;

	// Blocks
	public static float blockFallingSpeed;
	public static float blockFallingGradient;
	public static float plantTime;
	public static bool autoGrab;

	// Spawner
	public static float spawnHeight;
	public static GameObject[] spawnlist;

	// Difficulty curve
	public static float initialSpawnGap;
	public static float initialSpawnGapSlope;
	public static float spawnGapLimit;
}

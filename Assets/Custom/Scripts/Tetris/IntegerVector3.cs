using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A vector of integers with dimension three

public struct IntegerVector3 {
	public int x, y, z;

	public IntegerVector3 (int x = 0, int y = 0, int z = 0) {
		this.x = x;
		this.y = y;
		this.z = z;
	}
	public IntegerVector3 (Vector3 v) {
		x = Mathf.RoundToInt(v.x);
		y = Mathf.RoundToInt(v.y);
		z = Mathf.RoundToInt(v.z);
	}

	public Vector3 ToVector3 () {
		return new Vector3 (x, y, z);
	}

	// quick notation for 3d array manipulation with IntegerVector3 as index
	public T At<T> (T [,,] arr) {
		return arr[x, y, z];
	}
	public T Set<T> (T [,,] arr, T val) {
		T prev = At (arr);
		arr [x, y, z] = val;
		return prev;
	}
	public bool inBounds<T> (T [,,] arr) {
		return 
			0 <= x && x < arr.GetLength(0) &&
			0 <= y && y < arr.GetLength(1) &&
			0 <= z && z < arr.GetLength(2);
	}

	// add IntegerVector3
	public static IntegerVector3 operator + (IntegerVector3 lhs, IntegerVector3 rhs) {
		return new IntegerVector3 (lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
	}

	// rotate IntegerVector3
	public static IntegerVector3 operator * (Quaternion lhs, IntegerVector3 rhs) {
		return new IntegerVector3 (lhs * rhs.ToVector3());
	}
}

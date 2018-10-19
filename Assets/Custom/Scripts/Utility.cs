using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// contains any generic code used by any other script

public static class Utility {
	public static class Distance {
		public static float Euclidean (Vector3 v, Vector3 u) {
			v -= u;
			return Mathf.Sqrt(v.x*v.x + v.y*v.y + v.z*v.z);
		}
		public static float King (Vector3 v, Vector3 u) {
			v -= u;
			return Mathf.Max(Mathf.Max(Mathf.Abs(v.x), Mathf.Abs(v.y)), Mathf.Abs(v.z));
		}
		public static float Manhattan (Vector3 v, Vector3 u) {
			v -= u;
			return Mathf.Abs(v.x) + Mathf.Abs(v.y) + Mathf.Abs(v.z);
		}
		public static float Euclidean2D (Vector3 v, Vector3 u) {
			v.y = u.y = 0;
			return Euclidean (v, u);
		}
		public static float King2D (Vector3 v, Vector3 u) {
			v.y = u.y = 0;
			return King (v, u);
		}
		public static float Manhattan2D (Vector3 v, Vector3 u) {
			v.y = u.y = 0;
			return Manhattan (v, u);
		}

	}
	public static class Rotation {
		// return orthogonal vector closest to v
		private static Vector3 SnapOrthogonal(Vector3 v) {
			if (Mathf.Abs(v.x) < Mathf.Abs(v.y)) {
				v.x = 0;
				if (Mathf.Abs(v.y) < Mathf.Abs(v.z))
					v.y = 0;
				else
					v.z = 0;
			} else {
				v.y = 0;
				if (Mathf.Abs(v.x) < Mathf.Abs(v.z))
					v.x = 0;
				else
					v.z = 0;
			}
			return v;
		}

		// return orthagonal rotation closest to rotation of t
		public static Quaternion SnapOrthogonal (Transform t) {
			Vector3 forward = SnapOrthogonal(t.forward);
			Vector3 up = SnapOrthogonal (t.up);
			return Quaternion.LookRotation (forward, up);
		}
	}
	public static class Scalar {
		// return a random value in [lower, upper)
		public static float Rand (float lower, float upper) {
			return lower + (upper-lower)*Random.value;
		}
		public static float Rand (float upper) {
			return Rand (0, upper);
		}
		public static float Rand () {
			return Rand (0, 1);
		}
		public static int RandInt (int lower, int upper) {
			return Mathf.FloorToInt (Rand(lower, upper));
		}
		public static int RandInt (int upper) {
			return RandInt (0, upper);
		}
	}
	public static class Array {
		public static T RandElement<T> (T[] arr) {
			return arr [Scalar.RandInt (arr.Length)];
		}
	}
}


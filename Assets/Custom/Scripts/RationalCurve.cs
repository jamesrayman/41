using System.Collections;
using System.Collections.Generic;

// Models a transformation of the curve f(x) = 1/x

public class RationalCurve {
	float a, b, c;
	float current;

	public RationalCurve (float initial, float initialSlope, float limit) {
		b = limit;
		c = (initial - limit)/initialSlope;
		a = -c * (initial - limit);

		current = 0;
	}
	public float Evaluate (float x) {
		return a / (x - c) + b;
	}
	public float Evaluate () {
		return Evaluate (current);
	}
	public void Advance (float step) {
		current += step;
	}
	public void Advance () {
		Advance (1);
	}
	public void Reset () {
		current = 0;
	}
}

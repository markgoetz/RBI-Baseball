using UnityEngine;
using System.Collections;

public class ThrownPitch {
	public Pitch pitch;
	public Vector2 startLocation;
	public Vector2 endLocation;
	public float speedMultiplier;
	public float movementMultiplier;

	private Vector2 _bezierControlPoint;
	
	public ThrownPitch(Pitch p, Vector2 start, Vector2 end, float speed, float movement) {
		pitch = p;
		startLocation = start;
		endLocation = end;
		speedMultiplier = speed;
		movementMultiplier = movement;
		
		_setControlPoint();
	}
	
	private void _setControlPoint() {
		Vector2 mid_point = Vector2.Lerp (startLocation, endLocation, .5f);
		Vector2 deflection = pitch.movement * movementMultiplier;
		_bezierControlPoint = mid_point + deflection;
	}
	
	public Vector2 getLocation(float t) {
		// TODO: Test cubic curves vs. quadratic curves
		return Vector2.Lerp(
			Vector2.Lerp (startLocation, _bezierControlPoint, t),
			Vector2.Lerp (_bezierControlPoint, endLocation, t),
			t
		);
	}
}

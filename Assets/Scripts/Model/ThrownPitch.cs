using UnityEngine;
using System.Collections;

public class ThrownPitch {
	public Pitch pitch;
	public Vector2 startLocation;
	public Vector2 endLocation;
	public float speedMultiplier;
	public float movementMultiplier;

	private Vector2 _bezierControlPointA;
	private Vector2 _bezierControlPointB;
	
	
	public ThrownPitch(Pitch p, Vector2 start, Vector2 end, float speed, float movement) {
		pitch = p;
		startLocation = start;
		endLocation = end;
		speedMultiplier = speed;
		movementMultiplier = movement;
		
		_setControlPoint();
	}
	
	private void _setControlPoint() {
		Vector2 deflection = pitch.movement * movementMultiplier;

		_bezierControlPointA = startLocation + deflection;
		_bezierControlPointB = endLocation + deflection;
	}
	
	public Vector2 getLocation(float t) {
		// TODO: Test cubic curves vs. quadratic curves
		
		// sup dawg herd u liek lerps
		Vector2 location = Vector2.Lerp (
			Vector2.Lerp (
				Vector2.Lerp (startLocation, _bezierControlPointA, t),
				Vector2.Lerp (_bezierControlPointA, _bezierControlPointB, t),
				t
			),
			Vector2.Lerp (
				Vector2.Lerp (_bezierControlPointA, _bezierControlPointB, t),
				Vector2.Lerp (_bezierControlPointB, endLocation, t),
				t
			),
			t
		);
		return location;
	}
	
	public Vector2 controlPointA {
		get { return _bezierControlPointA; }
	}

	
	public Vector2 controlPointB {
		get { return _bezierControlPointB; }
	}
}

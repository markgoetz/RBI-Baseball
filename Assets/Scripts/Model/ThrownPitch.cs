using UnityEngine;
using System.Collections;

public class ThrownPitch {
	public Pitch pitch;
	public Vector2 startLocation;
	public Vector2 endLocation;
	// TODO: Include pitch speed
	
	public ThrownPitch(Pitch p, Vector2 start, Vector2 end) {
		pitch = p;
		startLocation = start;
		endLocation = end;
	}
	
	public Vector2 getLocation(float t) {
	// TODO: Replace with Bezier curves
		return Vector2.Lerp(startLocation, endLocation, t);
	}
}

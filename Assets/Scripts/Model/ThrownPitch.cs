using UnityEngine;
using System.Collections;

public class ThrownPitch {
	public Pitch pitch;
	public Vector2 start_location;
	public Vector2 end_location;
	// TODO: Include pitch speed
	
	public ThrownPitch(Pitch p, Vector2 start, Vector2 end) {
		pitch = p;
		start_location = start;
		end_location = end;
	}
	
	public Vector2 getLocation(float t) {
	// TODO: Replace with Bezier curves
		return Vector2.Lerp(start_location, end_location, t);
	}
}

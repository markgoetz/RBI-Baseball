using UnityEngine;
using System.Collections;

public class PitchResultController : MonoBehaviour {
	public float hitRadius;
	
	public PitchResult GetPitchResult(Vector2 pitch_location, Vector2 swing_location) {
		// stub method
		return new PitchResult();
	}
	
	public static PitchResultController GetInstance() {
		return GameObject.FindGameObjectWithTag("Pitch Result Controller").GetComponent<PitchResultController>();
	}
}

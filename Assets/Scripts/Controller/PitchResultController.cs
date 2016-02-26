using UnityEngine;
using System.Collections;

public class PitchResultController : MonoBehaviour {
	public GameSettings settings;
	
	public PitchResult GetPitchResult(Character pitcher_stats, Vector2 pitch_location, Character batter_stats, Vector2 swing_location) {
		// stub method
		return new PitchResult();
	}

	public Vector2 GetHitVector(Character pitcher_stats, Vector2 pitch_location, Character batter_stats, Vector2 swing_location) {
		return new Vector2(0,0);
	}
	
	public static PitchResultController GetInstance() {
		return GameObject.FindGameObjectWithTag("Pitch Result Controller").GetComponent<PitchResultController>();
	}
}

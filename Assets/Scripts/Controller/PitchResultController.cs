using UnityEngine;
using System.Collections;

public class PitchResultController : MonoBehaviour {
	public GameSettings settings;
	
	public PitchResult GetPitchResult(Character pitcher_stats, Vector2 pitch_location, Character batter_stats, Vector2 swing_location) {
		// stub method
		return new PitchResult();
	}

	public BallHit GetBallHit(Character pitcher_stats, Vector2 pitch_location, Character batter_stats, Vector2 swing_location) {
		BallHit bh = new BallHit();

		bh.endPosition = new Vector2(100,0);
		bh.time = 2.0f;

		return bh;
	}
	
	public static PitchResultController GetInstance() {
		return GameObject.FindGameObjectWithTag("Pitch Result Controller").GetComponent<PitchResultController>();
	}
}

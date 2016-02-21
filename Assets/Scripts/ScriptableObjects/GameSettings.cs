using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Game Settings")]
public class GameSettings : ScriptableObject {
	public float hitRadius;

	public float BatterSwingRadius(Character batter_stats) {
		return .2f;
	}

	public float BatterSwingDelay(Character batter_stats) {
		return .33f;
	}

	public float PitcherSpreadRadius(Character pitcher_stats, Vector2 pitching_location) {
		return Vector2.Distance(pitcher_stats.pitchingSweetSpot, pitching_location);
	}

	public float PitchMovementMultiplier(Character pitcher_stats, Vector2 pitching_location) {
		float multiplier = 1.0f;
		// Distance from sweet spot
		multiplier -= PitcherSpreadRadius(pitcher_stats, pitching_location);
	
		// TODO: dexterity stat
		// TODO: fatigue
		
		multiplier = Mathf.Clamp01(multiplier);

		return multiplier;
	}

	public float PitchSpeedMultiplier(Character pitcher_stats, Vector2 pitching_location) {
		return 1f;
	}
}

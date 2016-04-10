using UnityEngine;
using System.Collections;

public class PitchResultCalculator {
	public GameSettings settings;

	public PitchResult CalculatePitchResult(Character pitcher_stats, Vector2 pitch_location, Character batter_stats, Vector2 swing_location) {
		// stub method
		PitchResult result = new PitchResult();

		// first calculate if the player hit or not
		// then call GetBallHit()
		// see how long it takes for the fielder to catch and throw the ball
		// determine how far the baserunners make it

		switch (Random.Range(0,3)) {
			case 0:
				result.type = PitchResultType.Ball;
				break;
			case 1:
				result.type = PitchResultType.Foul;
				break;
			case 2:
				result.type = PitchResultType.InPlay;
				result.outs = Random.Range(0,2);
				result.basesAdvanced = Random.Range(1,4);
				break;
			case 3:
				result.type = PitchResultType.Strike;
				break; 
		}
  

		return result;
	}

	public BallHit GetBallHit(Character pitcher_stats, Vector2 pitch_location, Character batter_stats, Vector2 swing_location) {
		// stub method
		BallHit bh = new BallHit();

		bh.endPosition = new Vector2(100,0);
		bh.time = 2.0f;

		return bh;
	}
}

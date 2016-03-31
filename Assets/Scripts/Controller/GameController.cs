using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public ThrownPitchController pitchedBall;
		
	private BatterController _batter;
	private PitcherController _pitcher;
	private PitchResultController _pitchResult;
	
	void Awake() {
		_batter = BatterController.GetInstance();
		_pitcher = PitcherController.GetInstance();
		_pitchResult = PitchResultController.GetInstance();
	}
	
	void Start() {
		StartCoroutine("gameLoop");
	}
	
	private IEnumerator gameLoop() {
		
		_inningStart();

		while (!_pitchResult.IsInningOver) {

			// Step 1: Wait for the pitcher to select a pitch
			_pitcher.PromptForPitch();
			
			while (!_pitcher.pitchReady) {
				yield return null;
			}
			
			pitchedBall.thrownPitch = _pitcher.GetThrownPitch();
			
			// Step 2: Throw the pitch.
			_pitcher.StartPitch();
			
			while (!pitchedBall.isSpawned) {
				yield return null;
			}
			
			// Step 3: Batter adjusts their location and pitch advances.  Loop until pitch is done.
			while (!pitchedBall.isDone) {
				_pitcher.BeforeTurn();
				_batter.BeforeTurn();

				while (!_batter.swingReady) {
					yield return null;
				}

				_pitcher.AfterTurn();
				_batter.AfterTurn();
				
				pitchedBall.AdvanceBy(_batter.swingPromptDelay);
				while (pitchedBall.isMoving) {
					yield return null;
				}
			}
			
			// Step 4: Batter swings at the pitch
			_batter.Swing();

			while (_batter.IsSwinging) {
				yield return null;
			}
			
			// Step 5: process the outcome.
			_pitchResult.HandleResult(_pitcher.character, pitchedBall.location, _batter.character, _batter.swingLocation);

			while (!_pitchResult.IsResultDone) {
				yield return null;
			}

			// Step 7: Get ready for next time
			if (_pitchResult.IsBatterDone) {
				_nextBatter();
			}

			pitchedBall.Reset();
			_batter.ResetAfterPitch();
			_pitcher.ResetAfterPitch();
			_pitchResult.ResetAfterPitch();
		}
		
		_inningOver();
	}
	
	public void SpawnPitch() {
		pitchedBall.Spawn();
	}
		
	public void PitchHit() {
	
	}
	
	private void _nextBatter() {
	
	}
	
	private void _inningStart() {
	}

	
	private void _inningOver() {
		
	}
										
	public static GameController GetInstance() {
		return GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
	}
}

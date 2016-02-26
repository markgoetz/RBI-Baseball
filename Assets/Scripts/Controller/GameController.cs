using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public ThrownPitchController pitchedBall;
		
	private BatterController _batter;
	private PitcherController _pitcher;
	private BaseRunnerController _baseRunners;
	private PitchResultController _pitchResult;
	
	private int _outs;
	private bool _isPitchDone;
	
	void Awake() {
		_batter = BatterController.GetInstance();
		_pitcher = PitcherController.GetInstance();
		_baseRunners = BaseRunnerController.GetInstance();
		_pitchResult = PitchResultController.GetInstance();
	}
	
	void Start() {
		StartCoroutine("gameLoop");
	}
	
	private IEnumerator gameLoop() {
		
		_inningStart();

		while (!_isInningOver()) {
		
		
			_isPitchDone = false;
			
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
			
			// Step 5: process the outcome.
			PitchResult result = _pitchResult.GetPitchResult(_pitcher.character, _pitcher.pitchLocation, _batter.character, _batter.swingLocation);
			
			if (result.type == PitchResultType.InPlay) {
				_outs += result.outs;
				_baseRunners.AdvanceRunners(result.basesAdvanced);
			}
			
			// Step 6: display the results.
			_displayResults(result);
			
			while (!_isPitchDone) {
				yield return null;
			}
			
			// Step 7: Get ready for next time
			pitchedBall.Reset();
			_batter.Reset();
			_pitcher.Reset();
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
		_outs = 0;
	}
	
	private bool _isInningOver() {
		return (_outs >= 3);
	}
	
	private void _inningOver() {
		
	}
	
	private void _displayResults (PitchResult result) {
		_isPitchDone = true; // stub
	}
										
	public static GameController GetInstance() {
		return GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
	}
}

using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public ThrownPitchController pitchedBall;
		
	private BatterController _batter;
	private PitcherController _pitcher;
	private BaseRunnerController _baseRunners;
	
	private int _outs;
	
	void Awake() {
		_batter = BatterController.GetInstance();
		_pitcher = PitcherController.GetInstance();
		_baseRunners = BaseRunnerController.GetInstance();
	}
	
	void Start() {
		StartCoroutine("gameLoop");
	}
	
	private IEnumerator gameLoop() {
		
		_inningStart();

		while (!_isInningOver()) {
			
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
				_batter.SetUnready();
				_batter.PromptForSwing();
				while (!_batter.swingReady) {
					yield return null;
				}
				
				pitchedBall.AdvanceBy(_batter.swingPromptDelay);
				while (pitchedBall.isMoving) {
					yield return null;
				}
			}
			
			// Step 4: Batter swings at the pitch
			_batter.Swing();
			
			// Step 5: process the outcome.
			
			
			// Step 6: Get ready for next time
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
	
	public void Out() {
		_outs++;
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
										
	public static GameController getInstance() {
		return GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
	}
}

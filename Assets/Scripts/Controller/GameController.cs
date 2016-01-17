using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public ThrownPitchController pitchedBall;
	public float TickTime;
		
	private BatterController batter;
	private PitcherController pitcher;
	private BaseRunnerController baseRunners;
	
	private int outs;
	
	void Awake() {
		batter = BatterController.getInstance();
		pitcher = PitcherController.getInstance();
		baseRunners = BaseRunnerController.getInstance();
	}
	
	void Start() {
		StartCoroutine("gameLoop");
	}
	
	private IEnumerator gameLoop() {
		
		_inningStart();

		while (!_isInningOver()) {
			
			// Step 1: Wait for the pitcher to select a pitch
			pitcher.PromptForPitch();
			
			while (!pitcher.pitchReady) {
				yield return null;
			}
			
			pitchedBall.Pitch = pitcher.getThrownPitch();
			
			// Step 2: Throw the pitch.
			pitcher.StartPitch();
			
			while (!pitchedBall.IsSpawned) {
				yield return null;
			}
			
			// Step 3: Batter adjusts their location and pitch advances.  Loop until pitch is done.
			while (!pitchedBall.IsDone) {
			
				batter.PromptForSwing();
				while (!batter.swingReady) {
					yield return null;
				}
				
				pitchedBall.AdvanceBy(TickTime);
				while (pitchedBall.IsMoving) {
					yield return null;
				}
			}
			
			// Step 4: Batter swings at the pitch
			batter.Swing();
			
			// Step 5: process the outcome.
			
			
			// Step 6: Get ready for next time
			pitchedBall.Reset();
			batter.Reset();
			pitcher.Reset();
		}
		
		_inningOver();
	}
	
	public void SpawnPitch() {
		pitchedBall.Spawn();
	}
	
	
	public void PitchHit() {
	
	}
	
	public void Out() {
		outs++;
	}
	
	private void _nextBatter() {
	
	}
	
	private void _inningStart() {
		outs = 0;
	}
	
	private bool _isInningOver() {
		return (outs >= 3);
	}
	
	private void _inningOver() {
		
	}
										
	public static GameController getInstance() {
		return GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
	}
}

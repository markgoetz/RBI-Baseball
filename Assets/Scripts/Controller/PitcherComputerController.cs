using UnityEngine;
using System.Collections;

public class PitcherComputerController : PitcherController {
	public float delayBetweenPitches;

	void Awake() {
		_Init();
	}

	void Start() {
		_sprite.Fade();
	}

	
	public override void PromptForPitch () {
		_pitchReady = false;
		
		StartCoroutine("DelayBeforePitchCoroutine");
	}
	
	private IEnumerator DelayBeforePitchCoroutine() {
		yield return new WaitForSeconds(delayBetweenPitches);
		
		_selectPitchAndLocation();
	}
	
	
	private void _selectPitchAndLocation() {
		// TODO: AI.
		SelectPitch(Random.Range(0, pitches.size - 1));
		_pitchLocation = new Vector2(Random.value, Random.value);
		_pitchReady = true;
	}
}

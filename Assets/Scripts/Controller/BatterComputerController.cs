using UnityEngine;
using System.Collections;

public class BatterComputerController : BatterController {
	public ThrownPitchController thrown_pitch;

	void Awake() {
		_init();
		sprite.Fade();
	}

	public override void PromptForSwing() {
		swing_location = _getLocation();
		swing_ready = true;
	}

	public void PitchDone() {
		//TODO: animation has to anticipate the pitch somehow.
		sprite.playSwingAnimation(swing_location);
	}
	
	private Vector2 _getLocation() {
		return new Vector2(Random.value, Random.value);
	}
}

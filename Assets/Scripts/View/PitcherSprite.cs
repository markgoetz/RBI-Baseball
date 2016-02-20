using UnityEngine;
using System.Collections;

public class PitcherSprite : GameCharacterSprite {

	private PitcherController _controller;

	protected override void Awake () {
		base.Awake();
		_controller = PitcherController.GetInstance();
	}
	
	public void PlayThrowAnimation (int pitch_number) {
		// TODO: Possibly set different animations depending on pitch location and type
		_anim.SetTrigger ("throwpitch");
	}
	
	public void SpawnPitchTrigger() {
		_controller.SpawnPitch();
	}

}

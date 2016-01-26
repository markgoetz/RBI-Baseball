﻿using UnityEngine;
using System.Collections;

public class BatterComputerController : BatterController {
	public ThrownPitchController thrownPitch;
	public float delayBeforeSwing;

	void Awake() {
		_Init();
		_sprite.Fade();
	}

	public override void PromptForSwing() {
		StartCoroutine("_DelaySwingCoroutine");
	}
	
	private IEnumerator _DelaySwingCoroutine() {
		yield return new WaitForSeconds(delayBeforeSwing);
	
		_swingLocation = _GetLocation();
		_swingReady = true;
	}

	public void PitchDone() {
		//TODO: animation has to anticipate the pitch somehow.
		_sprite.PlaySwingAnimation(_swingLocation);
	}
	
	private Vector2 _GetLocation() {
		return new Vector2(Random.value, Random.value);
	}
}

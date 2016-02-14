using UnityEngine;
using System.Collections;

public class BatterComputerController : BatterController {
	public ThrownPitchController thrownPitch;
	public float delayBeforeSwing;

	void Awake() {
		_Init();
		_sprite.Fade();
	}
	
	void Start() {
		Reset ();
	}

	public override void PromptForSwing() {
		StartCoroutine("_DelaySwingCoroutine");
	}
	
	private IEnumerator _DelaySwingCoroutine() {
		yield return new WaitForSeconds(delayBeforeSwing);
	
		swingLocation = _GetLocation();
		_swingReady = true;
	}
	
	private Vector2 _GetLocation() {
		// TODO: AI.
		return swingLocation + Random.insideUnitCircle * swingAdjustRadius;
	}
}

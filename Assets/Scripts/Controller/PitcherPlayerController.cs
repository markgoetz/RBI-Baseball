using UnityEngine;
using System.Collections;

public class PitcherPlayerController : PitcherController {
	private PitchUIController _uiController;

	protected override void Awake() {
		base.Awake();
		
		_uiController = PitchUIController.GetInstance() as PitchUIController;
	}
	
	protected override void Start() {
		base.Start();
		_uiController.ResetView();
	}
	
	public override void PromptForPitch () {
		_pitchReady = false;
		_uiController.ResetView();
	}
}

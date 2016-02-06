using UnityEngine;
using System.Collections;

public class PitcherPlayerController : PitcherController {
	private PitchUIController _uiController;

	void Awake() {
		_init();
		
		_uiController = PitchUIController.GetInstance() as PitchUIController;
	}
	
	void Start() {
		_uiController.ResetView();
	}
	
	public override void PromptForPitch () {
		_pitchReady = false;
		_uiController.ResetView();
	}
}

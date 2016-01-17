using UnityEngine;
using System.Collections;

public class PitcherPlayerController : PitcherController {
	private PitchUIController uiController;

	void Awake() {
		_init();
		
		uiController = PitchUIController.getInstance() as PitchUIController;
		uiController.Reset();
	}
	
	public override void PromptForPitch () {
		pitch_ready = false;
		uiController.Reset();
	}
}

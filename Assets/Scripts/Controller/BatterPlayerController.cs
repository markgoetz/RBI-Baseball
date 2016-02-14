using UnityEngine;
using System.Collections;

public class BatterPlayerController : BatterController {
	private BatUIController _uiController;

	void Awake() {
		_Init();
		_uiController = BatUIController.GetInstance() as BatUIController;
	}
	
	void Start() {
		Reset ();
	}

	public override void PromptForSwing() {
		_uiController.PromptForSwing();
	}
}

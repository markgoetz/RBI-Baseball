using UnityEngine;
using System.Collections;

public class BatterPlayerController : BatterController {
	private BatUIController _uiController;

	protected override void Awake() {
		base.Awake();
		_uiController = BatUIController.GetInstance() as BatUIController;
	}
	
	protected override void Start() {
		base.Start();
		Reset ();
	}

	protected override void PromptForSwing() {
		_uiController.PromptForSwing();
	}
}

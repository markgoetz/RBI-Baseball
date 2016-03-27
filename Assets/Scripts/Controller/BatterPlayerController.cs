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
		ResetAfterPitch ();
	}

	protected override void PromptForSwing() {
		_uiController.PromptForSwing();
	}

	public override void ResetAfterPitch() {
		base.ResetAfterPitch();
		_uiController.ResetView();
	}
}

using UnityEngine;
using System.Collections;

public class BatUIController : FieldingUIController {
	public BattingCursor cursor;
	public BattingRadiusView radiusView;
	private BatterController _batterController;

	void Awake() {
		_Init();
		_batterController = BatterController.GetInstance();
	}

	void Start() {
		ResetView ();
	}
	
	public void ResetView() {
		radiusView.radius = _batterController.swingAdjustRadius;
		radiusView.SetStrikeZoneLocation(_batterController.swingLocation);
		_ChangeToWaitView();
	}

	public override void LocationSelected(Vector2 location) {
		_batterController.swingLocation = location;
		radiusView.SetStrikeZoneLocation(location);
		_ChangeToWaitView ();
	}

	public void PromptForSwing() {
		_ChangeToSwingView();
	}
	
	private void _ChangeToWaitView() {
		cursor.SetVisible(false);
		radiusView.SetVisible(false);
	}
	
	private void _ChangeToSwingView() {
		radiusView.SetStrikeZoneLocation(_batterController.swingLocation);
		cursor.SetVisible (true);
		radiusView.SetVisible(true);
	}
	
	public override void PitchDone() {
		_ChangeToWaitView();
	}
}

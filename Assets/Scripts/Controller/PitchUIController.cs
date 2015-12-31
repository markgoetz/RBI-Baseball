using UnityEngine;
using System.Collections;

public class PitchUIController : FieldingUIController {
	void Start() {
		_changeToSelectionView();
		
	}

	public override void pitchSelected(int pitch_number) {
		pitcherController.currentPitch = pitches.get(pitch_number);
		
		_changeToLocationView();
	}
	
	public override void locationSelected(Vector2 location) {
		pitcherController.pitchLocation = location;
		pitcherController.ThrowPitch();
		_hideUI ();
	}
	
	private void _changeToLocationView() {
		pitchIcons.hide();
		cursor.setVisible (true);
		strikeZone.show();
	}
	
	private void _hideUI() {
		pitchIcons.hide();
		cursor.setVisible (false);
		strikeZone.hide();
	}
	
	private void _changeToSelectionView() {
		pitchIcons.enable();
		cursor.setVisible (false);
		strikeZone.hide();
	}
}

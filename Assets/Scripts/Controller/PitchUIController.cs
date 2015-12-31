using UnityEngine;
using System.Collections;

public class PitchUIController : FieldingUIController {
	public override void pitchSelected(int pitch_number) {
		pitcherController.currentPitch = pitches.get(pitch_number);
		
		_changeToLocationView();
	}
	
	public override void locationSelected(Vector2 location) {
		pitcherController.pitchLocation = location;
		_hideUI ();
	}
	
	private void _changeToLocationView() {
		pitchIcons.hide();
		strikeZone.show();
	}
	
	private void _hideUI() {
		pitchIcons.hide();
		strikeZone.hide();
	}
	
	private void _changeToSelectionView() {
		pitchIcons.enable();
		strikeZone.hide();
	}
}

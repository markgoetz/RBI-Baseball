using UnityEngine;
using System.Collections;

public class PitchUIController : FieldingUIController {
	public PitchIconView pitchIcons;
	public PitchingCursor cursor;
	private PitcherController pitcherController;

	void Awake() {
		_init();
		pitcherController = PitcherController.getInstance();
		
		runners.setIsPlayer(false);
	}

	void Start() {
		Reset ();
	}
	
	public void Reset() {
		_changeToSelectionView();
	}

	public override void pitchSelected(int pitch_number) {
		pitcherController.currentPitch = pitches.get(pitch_number);
		
		_changeToLocationView();
	}
	
	public override void locationSelected(Vector2 location) {
		pitcherController.pitchLocation = location;
		_changeToPitchView ();
	}
	
	private void _changeToLocationView() {
		pitchIcons.setVisible(false);
		cursor.setVisible (true);
		strikeZone.setVisible(true);
	}
	
	private void _changeToPitchView() {
		pitchIcons.setVisible(false);
		cursor.setVisible (false);
		strikeZone.setVisible(true);
	}
	
	private void _changeToSelectionView() {
		pitchIcons.setVisible(true);
		cursor.setVisible(false);
		strikeZone.setVisible(true);
	}
	
	public override void PitchDone() {
		_changeToSelectionView();
	}
}

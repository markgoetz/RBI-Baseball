﻿using UnityEngine;
using System.Collections;

public class PitchUIController : FieldingUIController {
	public PitchIconView pitchIcons;
	public PitchingCursor cursor;
	private PitcherController _pitcherController;

	void Awake() {
		_Init();
		_pitcherController = PitcherController.GetInstance();
	}

	void Start() {
		ResetView ();
	}
	
	public void ResetView() {
		_ChangeToSelectionView();
	}

	public void PitchSelected(int pitch_number) {
		_pitcherController.SelectPitch(pitch_number);
		
		_ChangeToLocationView();
	}
	
	public override void LocationSelected(Vector2 location) {
		_pitcherController.pitchLocation = location;
		_ChangeToPitchView ();
	}
	
	private void _ChangeToLocationView() {
		pitchIcons.SetVisible(false);
		cursor.SetVisible (true);
		strikeZone.SetVisible(true);
	}
	
	private void _ChangeToPitchView() {
		pitchIcons.SetVisible(false);
		cursor.SetVisible (false);
		strikeZone.SetVisible(true);
	}
	
	private void _ChangeToSelectionView() {
		pitchIcons.SetVisible(true);
		cursor.SetVisible(false);
		strikeZone.SetVisible(true);
	}
}

﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ResultDebugView))]
public class ResultDebugUIController : FieldingUIController {
	public GameObject pitchIcon;
	public GameObject swingIcon;

	private int _mode;
	private Vector2 _pitchLocation;
	private Vector2 _swingLocation;

	private GameObject _pitchIcon;
	private GameObject _swingIcon;

	private ResultDebugView _view;

	void Awake () {
		_view = GetComponent<ResultDebugView>();
		_ResetPitch();
	}
	
	private void _ResetPitch () {
		_mode = 0;
	}

	public override void LocationSelected(Vector2 location) {
		// TODO: Show the icons in the proper place.

		if (_mode == 0) {
			_pitchLocation = location;
			_mode = 1;
			_pitchIcon = Instantiate(pitchIcon, strikeZone.StrikeZoneToWorldSpace(_pitchLocation), Quaternion.identity) as GameObject;
			_pitchIcon.GetComponent<SpriteFader>().enabled = false;
		}
		else if (_mode == 1) {
			_swingLocation = location;
			_mode = 2;
			_swingIcon = Instantiate(swingIcon, strikeZone.StrikeZoneToWorldSpace(_swingLocation), Quaternion.identity) as GameObject;
			_swingIcon.GetComponent<SpriteFader>().enabled = false;

		}
	}

	public void DisplayResult(Vector2 location) {
		_view.Display(location);
	}

	public void Clear() {
		Destroy(_swingIcon);
		Destroy(_pitchIcon);
		_ResetPitch();
	}

	public Vector2 pitchLocation {
		get { return _pitchLocation; }
	}

	public Vector2 swingLocation {
		get { return _swingLocation; }
	}

	public bool resultReady {
		get { return (_mode == 2); }
	}

	public bool resultDone {
		get { return (_mode == 2 && _view.Done); }
	}
}

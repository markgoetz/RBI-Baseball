using UnityEngine;
using System.Collections;

public class ResultDebugUIController : FieldingUIController {
	public GameObject pitchIcon;
	public GameObject hitIcon;

	private int _mode;
	private Vector2 _pitchLocation;
	private Vector2 _swingLocation;

	void Awake () {
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
		}
		else if (_mode == 1) {
			_swingLocation = location;
			_mode = 2;
		}
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
		get { return (_mode == 3); }
	}

	public void finishResult() {
		_mode = 3;
	}
}

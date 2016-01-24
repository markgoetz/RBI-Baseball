using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ThrownPitchView))]
public class ThrownPitchController : MonoBehaviour {
	public float pitchDuration;
	
	private ThrownPitch _pitch;
	private float _time = 0f;
	private ThrownPitchView _view;
	
	private bool _isDone;
	private bool _isSpawned;
	private bool _isMoving;
	
	public ThrownPitch pitch {
		get { return _pitch; }
		set {
			_pitch = value;
		}
	}
	
	void Awake() {
		_view = GetComponent<ThrownPitchView>();
	}
	
	public void AdvanceBy(float t) {
		StartCoroutine("advanceCoroutine", t);
	}
	
	private IEnumerator advanceCoroutine(float t) {
		float new_time = _time + t;
		_isMoving = true;
		
		while (_time < new_time) {
			Vector3 pitch_location = _pitch.getLocation(_time);
			pitch_location.z = _time;
			
			_view.setLocation(pitch_location);
			yield return null;
			
			_time += (Time.deltaTime / pitchDuration);
		}
				
		_isMoving = false;
				
		if (_time >= 1) {
			Finish();
		}
	}
	
	public bool isMoving {
		get { return _isMoving; }
	}
	
	private void _SetVisible(bool status) {
		_view.SetVisible(status);
	}
	
	public void Spawn() {
		_isSpawned = true;
		_SetVisible (true);
	}
	
	public void Finish() {
		_isDone = true;
	
		_view.ShowIcon();
	}
	
	public void Reset() {
		_isDone = false;
		_isSpawned = false;
		
		_time = 0;
		
		_view.setLocation(_pitch.startLocation);  // this prevents a one-frame graphic glitch on the next pitch
		_SetVisible (false);
	}
	
	public bool isDone {
		get { return _isDone; }
	}
	
	public bool isSpawned {
		get { return _isSpawned; }
	}
}

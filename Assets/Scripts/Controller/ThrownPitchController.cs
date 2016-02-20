using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ThrownPitchView))]
public class ThrownPitchController : MonoBehaviour {
	public float pitchDuration;
	
	private ThrownPitch _thrownPitch;
	private float _time = 0f;
	private ThrownPitchView _view;
	
	private bool _isDone;
	private bool _isSpawned;
	private bool _isMoving;
	
	public ThrownPitch thrownPitch {
		get { return _thrownPitch; }
		set {
			_thrownPitch = value;
			_view.facingRight = _thrownPitch.facingRight;
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
		_view.Unpause();
		
		Vector3 pitch_location;
		
		while (_time < new_time) {
			float z = _time * _thrownPitch.pitch.speed;
		
			pitch_location = _thrownPitch.getLocation(z);
			pitch_location.z = z;
			
			_view.setLocation(pitch_location);
			
			
			if (pitch_location.z >= 1) {
				Finish();
				yield break;
			}
			
			yield return null;
			
			_time += (Time.deltaTime / pitchDuration);
		}
		
		_view.Pause ();
		_isMoving = false;
	}
	
	public bool isMoving {
		get { return _isMoving; }
	}
	
	private void _SetVisible(bool status) {
		_view.SetVisible(status);
	}
	
	public void Spawn() {
		_isSpawned = true;
		_view.setLocation(thrownPitch.startLocation); // Use this to prevent a one-frame graphic glitch when the pitch is displayed
		_SetVisible (true);
	}
	
	public void Finish() {
		_isMoving = false;
		_isDone = true;
	
		_view.ShowIcon();
	}
	
	public void Reset() {
		_isDone = false;
		_isSpawned = false;
		
		_time = 0;
		
		_view.setLocation(_thrownPitch.startLocation);  // this prevents a one-frame graphic glitch on the next pitch
		_SetVisible (false);
	}
	
	public bool isDone {
		get { return _isDone; }
	}
	
	public bool isSpawned {
		get { return _isSpawned; }
	}
	
	void OnDrawGizmos() {
		if (_thrownPitch == null) return;
	
		StrikeZoneView debug_view = StrikeZoneView.GetInstance();
	
		Gizmos.color = Color.green;
		Gizmos.DrawSphere(debug_view.StrikeZoneToWorldSpace(_thrownPitch.startLocation), .1f);
		Gizmos.color = Color.white;
		Gizmos.DrawSphere(debug_view.StrikeZoneToWorldSpace(_thrownPitch.controlPointA), .1f);
		Gizmos.DrawSphere(debug_view.StrikeZoneToWorldSpace(_thrownPitch.controlPointB), .1f);
		Gizmos.color = Color.red;
		Gizmos.DrawSphere (debug_view.StrikeZoneToWorldSpace(_thrownPitch.endLocation), .1f);
	}
}

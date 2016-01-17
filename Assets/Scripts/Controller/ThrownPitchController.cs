using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ThrownPitchView))]
public class ThrownPitchController : MonoBehaviour {
	public float pitchDuration;
	private ThrownPitch pitch;
	private float time = 0f;
	private ThrownPitchView view;
	
	private bool is_done;
	private bool is_spawned;
	private bool is_moving;
	
	public ThrownPitch Pitch {
		get { return pitch; }
		set {
			pitch = value;
		}
	}
	
	void Awake() {
		view = GetComponent<ThrownPitchView>();
	}
	
	public void AdvanceBy(float t) {
		StartCoroutine("advanceCoroutine", t);
	}
	
	private IEnumerator advanceCoroutine(float t) {
		float new_time = time + t;
		is_moving = true;
		
		while (time < new_time) {
			
			Vector3 pitch_location = pitch.getLocation(time);
			pitch_location.z = time;
			
			view.setLocation(pitch_location);
			yield return null;
			
			time += (Time.deltaTime / pitchDuration);
		}
				
		is_moving = false;
				
		if (time > 1) {
			Finish();
		}
	}
	
	public bool IsMoving {
		get { return is_moving; }
	}
	
	private void _SetVisible(bool status) {
		view.SetVisible(status);
	}
	
	public void Spawn() {
		is_spawned = true;
		_SetVisible (true);
	}
	
	public void Finish() {
		is_done = true;
	
		view.showIcon();
	}
	
	public void Reset() {
		is_done = false;
		is_spawned = false;
		
		time = 0;
		
		view.setLocation(pitch.start_location);  // this prevents a one-frame graphic glitch on the next pitch
		_SetVisible (false);
	}
	
	public bool IsDone {
		get { return is_done; }
	}
	
	public bool IsSpawned {
		get { return is_spawned; }
	}
}

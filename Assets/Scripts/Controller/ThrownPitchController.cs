using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ThrownPitchView))]
public class ThrownPitchController : MonoBehaviour {
	public float pitchDuration;
	private ThrownPitch pitch;
	private float time = 0f;
	private ThrownPitchView view;
	
	private GameController gameController;
	
	public ThrownPitch Pitch {
		get { return pitch; }
		set {
			pitch = value;
		}
	}
	
	public void Prepare() {
		time = 0;
		view.setLocation(new Vector3(.5f,.5f,0));
	}
	
	void Awake() {
		view = GetComponent<ThrownPitchView>();
		FieldingMasterController master = FieldingMasterController.getInstance();
		gameController = master.gameController;
	}
	
	public void AdvanceBy(float t) {
		StartCoroutine("advanceCoroutine", t);
	}
	
	private IEnumerator advanceCoroutine(float t) {
		float new_time = time + t;
		
		while (time < new_time) {
			
			Vector3 pitch_location = pitch.getLocation(time);
			pitch_location.z = time;
			
			view.setLocation(pitch_location);
			yield return null;
			
			time += (Time.deltaTime / pitchDuration);
		}
				
		if (time > 1) {
			gameController.PitchDone();
			Done();
		}
		else {
			gameController.PitchAdvanced();
		}
	}
	
	public void SetVisible(bool status) {
		view.SetVisible(status);
	}
	
	public void Done() {
		view.setLocation(pitch.start_location);  // this prevents a one-frame graphic glitch on the next pitch
		SetVisible (false);
	}
}

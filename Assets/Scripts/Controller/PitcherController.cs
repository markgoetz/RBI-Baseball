using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PitcherSprite))]
public abstract class PitcherController : MonoBehaviour {
	public PitcherSprite sprite;
	public ThrownPitchController pitchedBall;
	
	private Pitch selected_pitch;
	private Vector2 pitch_location;
	
	void Start() {
		pitchedBall.SetVisible(false);
	}
	
	public Pitch currentPitch {
		set { selected_pitch = value; }
		get { return selected_pitch; }
	}
	
	public Vector2 pitchLocation {
		get { return pitch_location; }
		set { pitch_location = value; }
	}
	
	abstract public void StartPitch();
	abstract public void ThrowPitch();
}

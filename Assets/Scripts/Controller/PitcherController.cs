using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PitcherSprite))]
public abstract class PitcherController : MonoBehaviour {
	public PitcherSprite sprite;
	public ThrownPitchController pitchedBall;
	
	protected Pitch selected_pitch;
	protected Vector2 pitch_location;
	
	protected Player player_stats;
	
	void Start() {
		player_stats = new Player();
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
	
	public Vector2 SweetSpot {
		get { return player_stats.pitchingSweetSpot; }
	}
	
	abstract public void StartPitch();
	abstract public void ThrowPitch();
	abstract public void PitchAdvanced();
	abstract public void PitchDone();
	
	public static PitcherController getInstance() {
		return GameObject.FindGameObjectWithTag("Pitcher Controller").GetComponent<PitcherController>();
	}
}

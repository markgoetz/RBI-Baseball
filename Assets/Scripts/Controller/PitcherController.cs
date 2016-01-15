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
	
	public Player player {
		get { return player_stats; }
		set { player_stats = value; }
	}
	
	public float spreadRadius(Vector2 pitch_location) {
		return Vector2.Distance(pitch_location, player_stats.pitchingSweetSpot);
	}
	
	protected Vector2 getPitchLocationWithSpread(Vector2 pitch_location) {
		Vector2 spread = Random.insideUnitCircle * spreadRadius(pitch_location);
		// QUESTION: Does this get capped at [0-1]?
		return pitch_location + spread;
	}
	
	abstract public void StartPitch();
	abstract public void ThrowPitch();
	abstract public void PitchAdvanced();
	abstract public void PitchDone();
	
	public static PitcherController getInstance() {
		return GameObject.FindGameObjectWithTag("Pitcher Controller").GetComponent<PitcherController>();
	}
}

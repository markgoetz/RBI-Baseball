using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PitcherSprite))]
public abstract class PitcherController : MonoBehaviour {
	public PitcherSprite sprite;

	
	protected Pitch selected_pitch;
	protected Vector2 pitch_location;
	
	protected Player player_stats;
	protected bool has_pitch_location;
	protected bool pitch_ready;
	
	protected void _init() {
		player_stats = new Player();
	}
	
	public void Reset() {
		selected_pitch = null;
		has_pitch_location = false;
	}
	
	protected void _checkReady() {
		if (selected_pitch != null && has_pitch_location == true)
			pitch_ready = true;
	}
	
	public Pitch currentPitch {
		set {
			selected_pitch = value;
			_checkReady();
		}
		get { return selected_pitch; }
	}
	
	public Vector2 pitchLocation {
		get { return pitch_location; }
		set {
			pitch_location = value;
			has_pitch_location = true;
			_checkReady();
		}
	}
	
	public bool pitchReady {
		get { return pitch_ready; }
	}
	
	public Player player {
		get { return player_stats; }
		set { player_stats = value; }
	}
	
	public float spreadRadius(Vector2 pitch_location) {
		return Vector2.Distance(pitch_location, player_stats.pitchingSweetSpot);
	}
	
	protected Vector2 _getPitchLocationWithSpread(Vector2 pitch_location) {
		Vector2 spread = Random.insideUnitCircle * spreadRadius(pitch_location);
		return pitch_location + spread;
	}
	
	public ThrownPitch getThrownPitch() {
		ThrownPitch pitch = new ThrownPitch(currentPitch, new Vector2(.5f,.5f), _getPitchLocationWithSpread(pitchLocation));
		return pitch;	
	}
	
	public void StartPitch() {
		sprite.playThrowAnimation(this.currentPitch.number);
	}
	
	public void SpawnPitch() {
		GameController.getInstance().SpawnPitch();
	}
	
	abstract public void PromptForPitch();
	
	public static PitcherController getInstance() {
		return GameObject.FindGameObjectWithTag("Pitcher Controller").GetComponent<PitcherController>();
	}
}

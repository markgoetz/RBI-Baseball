using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PitcherSprite))]
public abstract class PitcherController : MonoBehaviour {
	public PitcherSprite sprite;

	
	protected Pitch _selectedPitch;
	protected Vector2 _pitchLocation;
	
	protected Player _playerStats;
	protected bool _hasPitchLocation;
	protected bool _pitchReady;
	
	protected void _init() {
		_playerStats = new Player();
	}
	
	public void Reset() {
		_selectedPitch = null;
		_hasPitchLocation = false;
	}
	
	protected void _checkReady() {
		if (_selectedPitch != null && _hasPitchLocation == true)
			_pitchReady = true;
	}
	
	public Pitch currentPitch {
		set {
			_selectedPitch = value;
			_checkReady();
		}
		get { return _selectedPitch; }
	}
	
	public Vector2 pitchLocation {
		get { return _pitchLocation; }
		set {
			_pitchLocation = value;
			_hasPitchLocation = true;
			_checkReady();
		}
	}
	
	public bool pitchReady {
		get { return _pitchReady; }
	}
	
	public Player player {
		get { return _playerStats; }
		set { _playerStats = value; }
	}
	
	public float SpreadRadius(Vector2 pitch_location) {
		return Vector2.Distance(pitch_location, _playerStats.pitchingSweetSpot);
	}
	
	protected Vector2 _GetPitchLocationWithSpread(Vector2 pitch_location) {
		Vector2 spread = Random.insideUnitCircle * SpreadRadius(pitch_location);
		return pitch_location + spread;
	}
	
	private float _GetMovementMultiplier(Vector2 end_location) {
		float multiplier = 1.0f;
		// Distance from sweet spot
		multiplier -= SpreadRadius(end_location);
	
		// TODO: dexterity stat
		// TODO: fatigue
		
		multiplier = Mathf.Clamp01(multiplier);
		
		// TODO: Pitcher's handedness.  If left-handed, multiply X by -1.
		
		return multiplier;
	}
	
	private float _GetSpeedMultiplier(Vector2 end_location) {
		// TODO: strength stat
		// TODO: fatigue
		return 1;
	}
	
	public ThrownPitch GetThrownPitch() {
		ThrownPitch pitch = new ThrownPitch(
			currentPitch,
			new Vector2(.5f,.5f),
			_GetPitchLocationWithSpread(pitchLocation),
			_GetMovementMultiplier(pitchLocation),
			_GetSpeedMultiplier(pitchLocation)
		);
		return pitch;	
	}
	
	public void StartPitch() {
		sprite.PlayThrowAnimation(currentPitch.number);
	}
	
	public void SpawnPitch() {
		GameController.getInstance().SpawnPitch();
	}
	
	abstract public void PromptForPitch();
	
	public static PitcherController GetInstance() {
		return GameObject.FindGameObjectWithTag("Pitcher Controller").GetComponent<PitcherController>();
	}
}

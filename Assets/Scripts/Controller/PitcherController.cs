using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PitcherSprite))]
public abstract class PitcherController : MonoBehaviour {
	public PitchList pitches;

	protected PitcherSprite _sprite;
	
	protected Pitch _selectedPitch;
	protected Vector2 _pitchLocation;
	
	protected Character _characterStats;
	protected bool _hasPitchLocation;
	protected bool _pitchReady;

	protected virtual void Awake() {
		_characterStats = new Character();
		_sprite = GetComponent<PitcherSprite>();
	}
	
	public void Reset() {
		_selectedPitch = null;
		_hasPitchLocation = false;
	}
	
	public void SelectPitch(int pitch_index) {
		_selectedPitch = pitches.Get(pitch_index);
		_checkReady();
	}
	
	protected void _checkReady() {
		if (_selectedPitch != null && _hasPitchLocation == true)
			_pitchReady = true;
	}
	
	public Pitch currentPitch {
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
	
	public Character character {
		get { return _characterStats; }
		set { _characterStats = value; }
	}




	/* ---- BEGIN CALCULATED STATISTIC SECTION ------- */

	public float SpreadRadius(Vector2 pitch_location) {
		return Vector2.Distance(pitch_location, _characterStats.pitchingSweetSpot);
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

	/* ---- END CALCULATED STATISTIC SECTION ------- */



	
	public ThrownPitch GetThrownPitch() {
		ThrownPitch pitch = new ThrownPitch(
			currentPitch,
			new Vector2(.5f,.5f),
			_GetPitchLocationWithSpread(pitchLocation),
			_GetSpeedMultiplier(pitchLocation),
			_GetMovementMultiplier(pitchLocation)
		);
		return pitch;	
	}
	
	public void StartPitch() {
		_sprite.PlayThrowAnimation(currentPitch.number);
	}
	
	public void SpawnPitch() {
		GameController.getInstance().SpawnPitch();
	}

	public void BeforeTurn() {
		_sprite.SetRunning(false);
	}

	public void AfterTurn() {
		_sprite.SetRunning(true);
	}
	
	abstract public void PromptForPitch();
	
	public static PitcherController GetInstance() {
		return GameObject.FindGameObjectWithTag("Pitcher Controller").GetComponent<PitcherController>();
	}
}

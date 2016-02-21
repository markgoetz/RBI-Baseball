using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BatterSprite))]
public abstract class BatterController : MonoBehaviour {
	public GameObject batterSwingIcon;
	public GameSettings settings;
	
	protected StrikeZoneView _strikeZoneView;
	protected Character _characterStats;
	protected BatterSprite _sprite;
	
	private Vector2 _swingLocation;
		
	protected bool _swingReady;
	
	public void Reset() {
		_swingReady = false;
		swingLocation = _characterStats.battingSweetSpot;
	}

	abstract protected void PromptForSwing();

	public bool swingReady {
		get { return _swingReady; }
	}

	public void BeforeTurn() {
		_swingReady = false;
		PromptForSwing();
		_sprite.SetRunning(false);
	}

	public void AfterTurn() {
		_sprite.SetRunning(true);
	}
	
	protected virtual void Awake() {
		_sprite = GetComponent<BatterSprite>();
		_characterStats = new Character();
		_strikeZoneView = StrikeZoneView.GetInstance();
	}

	protected virtual void Start() {
		_setCharacter();
	}
	
	public void Swing() {
		_sprite.PlaySwingAnimation(swingLocation);
		ShowIcon(swingLocation);
	}
	
	// The time between prompts to swing.
	public float swingPromptDelay {
		get {
			return settings.BatterSwingDelay(_characterStats);
		}
	}
	
	// The amount that the batter can adjust their swing spot by.
	public float swingAdjustRadius {
		get {
			return settings.BatterSwingRadius(_characterStats);
		}
	}
	
	public Vector2 swingLocation {
		get { return _swingLocation; }
		set {
			_swingLocation = value;
			_swingReady = true;
		}
	}
	
	
	public bool isInsideRadius(Vector2 strike_zone_location) {
		return (strike_zone_location - swingLocation).magnitude <= swingAdjustRadius;
	}
	
	
	public void ShowIcon(Vector2 strike_zone_location) {	
		Vector2 icon_position = _strikeZoneView.StrikeZoneToWorldSpace(strike_zone_location);
		Instantiate(batterSwingIcon, icon_position, Quaternion.identity);
	}

	public Character character {
		get { return _characterStats; }
		set { 
			_characterStats = value;
			_setCharacter();
		}
	}

	// Must be called after _characterStats is changed!
	private void _setCharacter() {
		_sprite.SetDirection(character.isRightHanded);
	}
	
	public static BatterController GetInstance() {
		return GameObject.FindGameObjectWithTag("Batter Controller").GetComponent<BatterController>();
	}
	
	void OnDrawGizmos() {
		try {
		
			Gizmos.color = Color.magenta;
			Gizmos.DrawSphere(
				_strikeZoneView.StrikeZoneToWorldSpace(
					swingLocation
			),
			.1f);
		}
		catch {
		
		}
	}
}
